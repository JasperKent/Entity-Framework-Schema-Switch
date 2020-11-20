using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace LanguageSwitchingSite.Data
{
    public class LanguageContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public LanguageContext(DbContextOptions<LanguageContext> options, IHttpContextAccessor httpContextAccessor)
            :base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Language => _httpContextAccessor.HttpContext.Request.Cookies["language"] ?? "English";

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TextFragment>().ToTable($"{Language}Fragments");
        }

        public DbSet<TextFragment> TextFragments { get; set; }
    }
}
