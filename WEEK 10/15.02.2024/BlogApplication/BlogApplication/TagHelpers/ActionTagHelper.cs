using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BlogApplication.TagHelpers;

public class ActionTagHelper : TagHelper
{
    public string Id { get; set; }
    public string ControllerName { get; set; }
    public string Text { get; set; }
    [ViewContext] [HtmlAttributeNotBound] public ViewContext ViewContext { get; set; }


    // public override void Process(TagHelperContext context, TagHelperOutput output)
    // {
    //     output.TagName = "div";
    //     output.Attributes.SetAttribute("class", "btn-group");
    //
    //     var button = new TagBuilder("button");
    //     button.Attributes.Add("type", "button");
    //     button.Attributes.Add("class", "btn btn-primary dropdown-toggle");
    //     button.Attributes.Add("data-bs-toggle", "dropdown");
    //     button.Attributes.Add("aria-expanded", "false");
    //     button.InnerHtml.Append(Text);
    //
    //     var ul = new TagBuilder("ul");
    //     ul.Attributes.Add("class", "dropdown-menu");
    //
    //     var liEdit = new TagBuilder("li");
    //
    //     var aEdit = new TagBuilder("a");
    //     aEdit.Attributes.Add("asp-action", "Edit");
    //     aEdit.Attributes.Add("asp-route-id", Id);
    //     aEdit.Attributes.Add("class", "dropdown-item");
    //     aEdit.InnerHtml.Append("Edit");
    //
    //     liEdit.InnerHtml.AppendHtml(aEdit);
    //
    //     var liDetails = new TagBuilder("li");
    //
    //     var aDetails = new TagBuilder("a");
    //     aDetails.Attributes.Add("asp-action", "Details");
    //     aDetails.Attributes.Add("asp-route-id", Id);
    //     aDetails.Attributes.Add("class", "dropdown-item");
    //     aDetails.InnerHtml.Append("Details");
    //
    //     liDetails.InnerHtml.AppendHtml(aDetails);
    //
    //     var liDelete = new TagBuilder("li");
    //
    //     var aDelete = new TagBuilder("a");
    //     aDelete.Attributes.Add("asp-action", "Delete");
    //     aDelete.Attributes.Add("asp-route-id", Id);
    //     aDelete.Attributes.Add("class", "dropdown-item");
    //     aDelete.InnerHtml.Append("Delete");
    //
    //     liDelete.InnerHtml.AppendHtml(aDelete);
    //
    //     var liUpload = new TagBuilder("li");
    //
    //     var aUpload = new TagBuilder("a");
    //     aUpload.Attributes.Add("asp-action", "Create");
    //     aUpload.Attributes.Add("asp-controller", "Images");
    //     aUpload.Attributes.Add("asp-area", "Admin");
    //     aUpload.Attributes.Add("asp-route-id", Id);
    //     aUpload.Attributes.Add("class", "dropdown-item");
    //     aUpload.InnerHtml.Append("Upload");
    //
    //     liUpload.InnerHtml.AppendHtml(aUpload);
    //
    //     ul.InnerHtml.AppendHtml(liEdit);
    //     ul.InnerHtml.AppendHtml(liDetails);
    //     ul.InnerHtml.AppendHtml(liDelete);
    //     ul.InnerHtml.AppendHtml(liUpload);
    //
    //     output.Content.AppendHtml(button);
    //     output.Content.AppendHtml(ul);
    // }

    private readonly IUrlHelperFactory _urlHelperFactory;

    public ActionTagHelper(IUrlHelperFactory urlHelperFactory)
    {
        _urlHelperFactory = urlHelperFactory;
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);

        output.TagName = "div";
        output.Attributes.SetAttribute("class", "btn-group");

        var button = new TagBuilder("button");
        button.Attributes.Add("type", "button");
        button.Attributes.Add("class", "btn btn-primary dropdown-toggle");
        button.Attributes.Add("data-bs-toggle", "dropdown");
        button.Attributes.Add("aria-expanded", "false");
        button.InnerHtml.Append(Text);

        var ul = new TagBuilder("ul");
        ul.Attributes.Add("class", "dropdown-menu");

        ul.InnerHtml.AppendHtml(CreateActionLink(urlHelper, "Edit", "Edit", ControllerName));
        ul.InnerHtml.AppendHtml(CreateActionLink(urlHelper, "Details", "Details", ControllerName));
        ul.InnerHtml.AppendHtml(CreateActionLink(urlHelper, "Delete", "Delete", ControllerName));
        ul.InnerHtml.AppendHtml(CreateActionLink(urlHelper, "Create", "Upload", "Images"));

        output.Content.AppendHtml(button);
        output.Content.AppendHtml(ul);
    }

    private TagBuilder CreateActionLink(IUrlHelper urlHelper, string action, string linkText,
        string controller = null)
    {
        var li = new TagBuilder("li");
        var a = new TagBuilder("a");
        a.Attributes.Add("href", urlHelper.Action(action, controller, new { area = "admin", id = Id }));
        a.Attributes.Add("class", "dropdown-item");
        a.InnerHtml.Append(linkText);
        li.InnerHtml.AppendHtml(a);
        return li;
    }
}