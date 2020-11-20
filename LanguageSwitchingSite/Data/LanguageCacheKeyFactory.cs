using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace LanguageSwitchingSite.Data
{
    public class LanguageCacheKeyFactory : IModelCacheKeyFactory
    {
        public object Create(DbContext context)
        {
            return new
            {
                Type = context.GetType(),
                Language = context is LanguageContext languageContext ? languageContext.Language : null
            };
        }
    }
}
