using DevScribe.API.Data;
using DevScribe.API.Models.Domain;
using DevScribe.API.Models.DTO;
using DevScribe.API.Reposotories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevScribe.API.Controllers
{
    //base route to controller: https://localhost:xxxx/api/categories
    [Route("api/[controller]")]
    [ApiController]
    public class CatergoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CatergoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            //Map DTO to Domain Model
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            await categoryRepository.CreateAsync(category);

            //Don't want to return Domain Model so must map Domain Model to DTO
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(response);
        }

        // GET: https://localhost:7036/api/Catergories
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await categoryRepository.GetAllAsync();

            //Map domain model to DTO
            var response = new List<CategoryDto>();
            foreach (var category in categories)
            {
                response.Add(new CategoryDto { 
                    Id = category.Id, 
                    Name = category.Name,
                    UrlHandle = category.UrlHandle
                });
            }

            return Ok(response);
        }
    }
}
