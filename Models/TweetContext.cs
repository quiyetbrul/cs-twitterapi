using Microsoft.EntityFrameworkCore;
namespace twitterapi.Models
{
    public class TweetContext : DbContext
    {
        public TweetContext(DbContextOptions<TweetContext> options) : base(options){}

        public DbSet<TweetItem> TweetItems{get;set;}
    }
}