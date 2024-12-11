using DevScribe.API.Data;
using DevScribe.API.Models.Domain;
using DevScribe.API.Reposotories.Interface;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await applicationDBContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetById(Guid id)
        {
           return await applicationDBContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category?> UpdateAsync(Category category)
        {
            var existingCategory = await applicationDBContext.Categories.FirstOrDefaultAsync(x =>x.Id == category.Id);

            if (existingCategory != null)
            {
                applicationDBContext.Entry(existingCategory).CurrentValues.SetValues(category);
                await applicationDBContext.SaveChangesAsync();
                return category;
            }

            return null;
        }
    }
}
