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

        [HttpGet]
        public async Task<List<T>> GetAll()
        {
            return await EntitiesService.GetItems();
        }

        [HttpGet("{key}")]
        public async Task<T> Get(Guid id)
        {
            return await EntitiesService.Get(id);
        }

        [HttpPost]
        public async Task<T> Create(T request)
        {
            return await EntitiesService.Insert(request);
        }
    }
}