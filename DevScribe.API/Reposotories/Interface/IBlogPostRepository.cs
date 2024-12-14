using DevScribe.API.Models.Domain;

namespace DevScribe.API.Reposotories.Interface
{
    public interface IBlogPostRepository
    {
        Task<BlogPost> CreateAsync(BlogPost blogPost);

        Task<IEnumerable<BlogPost>> GetAllAsync();
    }
}
