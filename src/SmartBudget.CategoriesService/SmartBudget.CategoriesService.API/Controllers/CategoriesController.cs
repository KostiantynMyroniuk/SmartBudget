using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartBudget.CategoriesService.Domain.Interfaces;

namespace SmartBudget.CategoriesService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        
    }
}
