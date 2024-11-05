using DevScribe.API.Data;
using DevScribe.API.Models.Domain;
using DevScribe.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevScribe.API.Controllers
{
    //base route to controller: https://localhost:xxxx/api/categories
    [Route("api/[controller]")]
    [ApiController]
    public class CatergoriesController : ControllerBase
    {
        private readonly ApplicationDBContext applicationDBContext;

        public CatergoriesController(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        //
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            //Map DTO to Domain Model
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            await applicationDBContext.Categories.AddAsync(category);
            await applicationDBContext.SaveChangesAsync();

            //Don't want to return Domain Model so must map Domain Model to DTO
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(response);
        }
    }
}
