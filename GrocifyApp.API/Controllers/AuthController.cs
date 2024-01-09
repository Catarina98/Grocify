﻿using AutoMapper;
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

namespace _1.MiniShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //public static new User User = new User() { Name = "name", Email = "email"};

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
            var getUser = await _userService.GetUserByEmail(user.Email); //I cant use CheckEmailExists because this method needs id too

            if (getUser != null)
            {
                var errors = new List<string> { GenericConsts.Errors.EmailAlreadyTaken };

                return BadRequest(new BadRequestModel { Errors = errors });
            }

            else
            {
                CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;

                string token = CreateToken(user);

                RegisterResponseModel responseModel = new RegisterResponseModel()
                {
                    PasswordHash = user.PasswordHash,
                    PasswordSalt = user.PasswordSalt,
                    Token = token
                };


                //makes sense insert when register on authenticator?
                var u = _mapper.Map<User>(user);

                await _userService.Insert(u);

                return responseModel;
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginRequestModel user)
        {
            var getUser = await _userService.GetUserByEmail(user.Email);

            if (getUser == null)
            {
                var errors = new List<string> { GenericConsts.Errors.UserPasswordIncorrect }; //and if we use the consts from DAL? If so, we only have one folder for consts, it seems more easier to search

                return BadRequest(new BadRequestModel { Errors = errors });
            }
            else
            {
                if (!VerifyPasswordHash(user.Password, getUser.PasswordHash, getUser.PasswordSalt))
                //if(user.Password != getUser.Password)
                {
                    var errors = new List<string> { GenericConsts.Errors.UserPasswordIncorrect };

                    return BadRequest(new BadRequestModel { Errors = errors });
                }
            }

            UserRequestModel userRequestModel = new UserRequestModel()
            {
                Name = getUser.Name,
                Email = getUser.Email,
                Password = getUser.Password,
                PasswordHash = getUser.PasswordHash,
                PasswordSalt = getUser.PasswordSalt,
            };

            string token = CreateToken(userRequestModel);

            return Ok(token);
        }

        private string CreateToken(UserRequestModel userAPI)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userAPI.Name)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

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
