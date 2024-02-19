using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BlogApplication.TagHelpers;


[HtmlTargetElement("email", TagStructure = TagStructure.WithoutEndTag)]
public class EmailTagHelper : TagHelper
{
    private readonly string domain = "code.edu.az";

    [HtmlAttributeName("kime")]
    public string MailTo { get; set; } = null!; // murat.vuranok
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "a";    // Replaces <email> with <a> tag
        string mailAddress = $"{MailTo}@{domain}".Replace(" ", "").ToLower();
        output.Attributes.SetAttribute("href", $"mailto:{mailAddress}");
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Content.SetContent(mailAddress);
    }
}


// <email mail-to="murat.vuranok"></email> -> end closing
// <email mail-to="murat.vuranok" /> -> self closing
// <a href="mailto:murat.vuranok@code.edu.az"> Support </a>