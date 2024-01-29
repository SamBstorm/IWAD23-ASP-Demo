using ASP_Demo_Session.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP_Demo_Session.Handlers
{
    public class UserLoggedSessionFilterAttribute : Attribute, IActionFilter
    {
        //Permet d'ajouter un comportement après exécution d'une Action dans un controller
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Doit rester vide, car aucune action attendue après exécution
            return;
        }

        //Permet d'ajouter un comportement avant exécution d'une Action dans un controller
        //Nous permettra de vérifier la session avant d'accéder à la page, sinon on le redirige vers le login
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("CurrentUser") is null)
                context.Result = new RedirectToActionResult(nameof(AuthController.Login), "Auth", null);
        }
    }
}
