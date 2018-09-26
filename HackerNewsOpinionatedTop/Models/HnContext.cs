using Microsoft.EntityFrameworkCore;

namespace HackerNewsOpinionatedTopApi.Models
{
    public class HnContext: DbContext
    {
        public HnContext(DbContextOptions<HnContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
    }
}
