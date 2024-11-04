using DevScribe.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DevScribe.API.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        //represents collection of entities from a type in relational database
        //allows to interact with entities in the database
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
