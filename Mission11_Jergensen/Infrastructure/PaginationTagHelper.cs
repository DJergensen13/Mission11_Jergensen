using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission11_Jergensen.Models.ViewModels;

namespace Mission11_Jergensen.Infrastructure;

[HtmlTargetElement ("div", Attributes="page-model")]
public class PaginationTagHelper : TagHelper
{
    private IUrlHelperFactory urlHelperFactory; // helps us build url we are about too build

    public PaginationTagHelper(IUrlHelperFactory temp)
    {
        urlHelperFactory = temp;
    }
    [ViewContext] // attribute, pulls information as this is called
    [HtmlAttributeNotBound] // Don't want users to be able to type over in url "view context" and get that information
    public ViewContext? ViewContext { get; set; } // give information about which view we came from, which controller, the view bag, etc.
    public string? PageAction { get; set; }
    public PaginationInfo PageModel { get; set; }
    public bool PageClassesEnabled { get; set; } = false;
    public string PageClass { get; set; } = String.Empty;
    public string PageClassNormal { get; set; } = String.Empty;
    public string PageClassSelected { get; set; } = String.Empty;

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (ViewContext != null && PageModel != null)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");
            for (int i = 1; i <= PageModel.TotalNumPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.Attributes["href"] = urlHelper.Action(PageAction, new { pageNum = i });
                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }
                tag.InnerHtml.Append(i.ToString()); // creates an a tag for every new page needed

                result.InnerHtml.AppendHtml(tag);
            }

            output.Content.AppendHtml(result.InnerHtml); // appends the new html to the end of the page
        }
    }
}