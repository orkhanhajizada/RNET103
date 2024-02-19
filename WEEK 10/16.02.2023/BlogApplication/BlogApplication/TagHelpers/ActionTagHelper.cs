using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BlogApplication.TagHelpers
{

    [HtmlTargetElement("td", Attributes = "actions")]
    public class ActionTagHelper : TagHelper
    {
        public int ModelId { get; set; }
        public string ControllerName { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string template = @$"<div class='btn-group'>
                                <button type='button' class='btn btn-warning dropdown-toggle btn-sm' data-bs-toggle='dropdown' aria-expanded='false'>
                                    <i class='fa fa-gear'></i>
                                </button>
                                <ul class='dropdown-menu'>
                                    <li> <a class='dropdown-item' asp-action='Edit'    href='/admin/{ControllerName}/edit/{ModelId}'>Edit</a> </li>
                                    <li> <a class='dropdown-item' asp-action='Details' href='/admin/{ControllerName}/details/{ModelId}'>Details</a>  </li>
                                    <li> <a class='dropdown-item' asp-action='Delete'  href='/admin/{ControllerName}/delete/{ModelId}'>Delete</a> </li> 
                                    <li> <a class='dropdown-item' asp-action='Delete'  href='/admin/{ControllerName}/delete/{ModelId}'>Delete</a> </li> 
                                </ul>
                            </div>";


            output.TagName = "td";
            output.Content.SetHtmlContent(template);
            output.TagMode = TagMode.StartTagAndEndTag;
        }

    }
}


/*
 
     <li>
                                        <a class='dropdown-item' asp-area='admin'
                                           asp-action='create'
                                           asp-controller='images'
                                           asp-route-id='{ModelId}'>Upload</a>
                                    </li>
 */