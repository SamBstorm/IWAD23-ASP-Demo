using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP_Demo_Session.Handlers
{
    public class AnonymousUserSessionFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!(context.HttpContext.Session.GetString("CurrentUser") is null))
                context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}
