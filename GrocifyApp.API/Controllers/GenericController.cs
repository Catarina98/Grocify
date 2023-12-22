using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace GrocifyApp.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class GenericRestController<T> : ControllerBase where T : BaseEntity
    {
        private IEntitiesService<T> EntitiesService { get; set; }
        public GenericRestController(IEntitiesService<T> _repository)
        {
            EntitiesService = _repository;
        }

        //[HttpGet]
        //public async Task<TResponse> GetAll()
        //{
        //    var result = await EntitiesService.GetItems();
        //    return Mapper.Map<T, TResponse>(result.FirstOrDefault());
        //}

        [HttpGet]
        public async Task<T> Get(Guid key)
        {
            return await EntitiesService.Get(key);
        }

        [HttpPost]
        public async Task<T> Create(T request)
        {
            return await EntitiesService.Insert(request);
        }
    }
}