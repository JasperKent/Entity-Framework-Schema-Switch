using LanguageSwitchingSite.Data;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;

namespace LanguageSwitchingSite.TagHelpers
{
    [HtmlTargetElement("fragment", Attributes ="ident", TagStructure = TagStructure.WithoutEndTag)]
    public class FragmentTagHelper : TagHelper
    {
        public string Ident { get; set; }

        private readonly LanguageContext _db;

        public FragmentTagHelper(LanguageContext db)
        {
            _db = db;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.AppendHtml(_db.TextFragments.Single(f => f.Id == Ident).Text);
        }
    }
}
