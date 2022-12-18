using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Data
{
    public class ScrapperDbContext : DbContext
    {
        public ScrapperDbContext(DbContextOptions<ScrapperDbContext> options) : base(options)
        {

        }
        public DbSet<ScrapperModel> Scrapper { get; set; }
        public DbSet<ScrapperLinkModel> ScrapperLink { get; set; }
    }
}
