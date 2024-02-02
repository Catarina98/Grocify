using AutoMapper;
using GrocifyApp.API.Data.Consts.ENConsts;
using GrocifyApp.API.Models.RequestModels;
using GrocifyApp.API.Models.ResponseModels;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace GrocifyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        public AuthController(IConfiguration configuration, IUserService userService, IMapper mapper)
        {
            _configuration = configuration;

            _userService = userService;

            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponseModel>> Register([FromBody] UserRequestModel user)
        {
            var getUser = await _userService.GetUserByEmail(user.Email);

            if (getUser != null)
            {
                var errors = new List<string> { GenericConsts.Errors.EmailAlreadyTaken };

                return BadRequest(new BadResponseModel { Errors = errors });
            }

            else
            {
                CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;

                var u = _mapper.Map<User>(user);

                await _userService.Insert(u);

                var loginResult = await Login(new LoginRequestModel() { Email = user.Email, Password = user.Password });

                var token = ((LoginResponseModel)((ObjectResult)loginResult.Result!).Value!).Token;

                RegisterResponseModel responseModel = new RegisterResponseModel()
                {
                    PasswordHash = user.PasswordHash,
                    PasswordSalt = user.PasswordSalt,
                    Token = token
                };

                return responseModel;
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseModel>> Login([FromBody] LoginRequestModel user)
        {
            var getUser = await _userService.GetUserByEmail(user.Email);

            Guid? houseId;

            if (getUser == null)
            {
                var errors = new List<string> { GenericConsts.Errors.UserPasswordIncorrect };

                return BadRequest(new BadResponseModel { Errors = errors });
            }
            else
            {
                if (!VerifyPasswordHash(user.Password, getUser.PasswordHash, getUser.PasswordSalt))
                //if(user.Password != getUser.Password)
                {
                    var errors = new List<string> { GenericConsts.Errors.UserPasswordIncorrect };

                    return BadRequest(new BadResponseModel { Errors = errors });
                }

                houseId = await _userService.GetUserDefaultHouseId(getUser.Id);

                if(houseId == null)
                {
                    var errors = new List<string> { GenericConsts.Errors.UserHasNoHouse };

                    return BadRequest(new BadResponseModel { Errors = errors });
                }
            }

            string token = CreateToken(getUser);

            var loginResponseModel = new LoginResponseModel
            {
                Token = token,
                UserId = getUser.Id,
                IsDarkMode = getUser.IsDarkMode
            };

            return Ok(loginResponseModel);
        }

        private string CreateToken(User userAPI)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userAPI.Name),
                new Claim(ClaimTypes.Email, userAPI.Email)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value ?? string.Empty));


            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;

                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
