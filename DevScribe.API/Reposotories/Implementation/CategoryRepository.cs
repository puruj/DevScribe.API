using DevScribe.API.Data;
using DevScribe.API.Models.Domain;
using DevScribe.API.Reposotories.Interface;

namespace DevScribe.API.Reposotories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext applicationDBContext;

        public CategoryRepository(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await applicationDBContext.Categories.AddAsync(category);
            await applicationDBContext.SaveChangesAsync();

            return category;
        }
    }
}
