using DevScribe.API.Models.Domain;

namespace DevScribe.API.Reposotories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<IEnumerable<Category>> GetAllAsync();
    }
}
