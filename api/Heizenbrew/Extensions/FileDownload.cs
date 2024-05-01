using Microsoft.AspNetCore.Mvc.Filters;

namespace heisenbrew_api.Extensions
{
    public class FileDownload : ActionFilterAttribute
    {
        public string FileName { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("Content-Disposition", $"attachment; filename={FileName}");
        }
    }
}
