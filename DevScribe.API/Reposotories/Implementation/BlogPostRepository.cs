using DevScribe.API.Data;
using DevScribe.API.Models.Domain;
using DevScribe.API.Reposotories.Interface;
using Microsoft.EntityFrameworkCore;

namespace DevScribe.API.Reposotories.Implementation
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly ApplicationDBContext dBContext;

        public BlogPostRepository(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<BlogPost> CreateAsync(BlogPost blogPost)
        {
            await dBContext.BlogPosts.AddAsync(blogPost);
            await dBContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await dBContext.BlogPosts.ToListAsync();
        }
    }
}
