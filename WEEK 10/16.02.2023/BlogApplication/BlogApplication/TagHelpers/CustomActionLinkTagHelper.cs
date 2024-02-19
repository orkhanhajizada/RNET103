using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace BlogApplication.TagHelpers;

[HtmlTargetElement("td", Attributes = "action-delete")]
[HtmlTargetElement("td", Attributes = "action-update")]
[HtmlTargetElement("td", Attributes = "action-edit")]
[HtmlTargetElement("td", Attributes = "action-create-*")]
[HtmlTargetElement("td", Attributes = "action-route")]
public class CustomActionLinkTagHelper : TagHelper
{
    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext ViewContext { get; set; }
    private readonly IUrlHelperFactory _urlHelperFactory;

    public CustomActionLinkTagHelper(IUrlHelperFactory urlHelperFactory)
    {
        _urlHelperFactory = urlHelperFactory;
    }


    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "td";
        StringBuilder sb = new StringBuilder();
        sb.Append(

            @"  <div class='btn-group'>
                                <button type='button' class='btn btn-warning dropdown-toggle btn-sm' data-bs-toggle='dropdown' aria-expanded='false'>
                                    <i class='fa fa-gear'></i>
                                </button>
                                <ul class='dropdown-menu'> " );

        var urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
        var allAttributes = context.AllAttributes;


        var id = allAttributes.FirstOrDefault(x => x.Name == "action-route");

        foreach (var attribute in allAttributes)
        {
            if (attribute.Name.StartsWith("action-") && !attribute.Name.Contains("route"))
            {
                var actionName = attribute.Name.Substring("action-".Length);
                var controllerName = attribute.Value.ToString();

                var actionUrl = urlHelper.Action(actionName, controllerName, new
                {
                    id = id.Value.ToString()
                });
                sb.Append($"<li><a class='dropdown-item' href='{actionUrl}'>{attribute.Name.Replace("action-", "")}</a></li>");
            }
        }

        sb.Append("</ul></div>");
        output.Content.SetHtmlContent(sb.ToString());
        output.TagMode = TagMode.StartTagAndEndTag;
    }
}

