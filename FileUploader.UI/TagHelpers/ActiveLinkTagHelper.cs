using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace FileUploader.UI.TagHelpers
{
    [HtmlTargetElement("a", Attributes = "asp-controller, asp-action")]
    public class ActiveLinkTagHelper : TagHelper
    {
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        [HtmlAttributeName("asp-controller")]
        public string Controller { get; set; }

        [HtmlAttributeName("asp-action")]
        public string Action { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var currentController = ViewContext.RouteData.Values["controller"]?.ToString();
            var currentAction = ViewContext.RouteData.Values["action"]?.ToString();
            var currentPath = ViewContext.HttpContext.Request.Path;

            if (string.Equals(currentController, Controller, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(currentAction, Action, StringComparison.OrdinalIgnoreCase))
            {
                var existingClasses = output.Attributes["class"]?.Value?.ToString();
                output.Attributes.SetAttribute("class", existingClasses == null ? "nav-link active" : $"{existingClasses} active");
            }
            else if (currentPath.StartsWithSegments($"/{Controller}", StringComparison.OrdinalIgnoreCase))
            {
                var existingClasses = output.Attributes["class"]?.Value?.ToString();
                output.Attributes.SetAttribute("class", existingClasses == null ? "nav-link active" : $"{existingClasses} active");
            }
            else
            {
                var existingClasses = output.Attributes["class"]?.Value?.ToString();
                output.Attributes.SetAttribute("class", existingClasses == null ? "nav-link" : existingClasses);
            }
        }
    }
}
