using InventoryControl.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using Story.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Controllers
{
    public class BaseController : Controller
    {
        #region Constructor
        public BaseController()
        {

        }
        #endregion

        #region Action Page
        protected IActionResult RedirectToErrorPage(string _title, string _message)
        {
            ViewData["Title"] = _title;
            ViewData["Message"] = _message;

            return View("~/Views/Shared/_ErrorPage.cshtml");
        }

        /*protected void SendNotification(Notification notifaction)
        {
            if (notifaction != null)
            {
                TempData["NotifTitle"] = notifaction.Title;
                TempData["NotifMessage"] = notifaction.Message;
                TempData["NotifType"] = notifaction.TypeNotif;

            }
        }*/
        #endregion

        #region Method
        protected string GetCurrentUser()
        {
            var user = HttpContext.Session.GetString("UserId");
            return user;
        }
        #endregion

        #region Custom Authorize Manager
        public class AuthorizeAttribute : ActionFilterAttribute, IActionFilter
        {
            #region Attribute Properties
            private string baseURL = string.Empty;
            private SiteSettings SiteSettings { get; set; }
            #endregion

            #region Overide OnActionExecuting
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                var url = $"{context.HttpContext.Request.Scheme}://{context.HttpContext.Request.Host}{context.HttpContext.Request.Path}{context.HttpContext.Request.QueryString}";
                if (context.HttpContext.Session.GetString("UserId") != null)
                {
                    
                    var cookieValue = context.HttpContext.Request.Cookies["AuthToken"];
                    var sessionValue = context.HttpContext.Session.GetString("AuthId");
                    if (cookieValue != sessionValue)
                        context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Action", "Index" }, { "Controller", "Home" }, { "returnUrl", url } });
                }
                else
                {
                    context.Result =
                          new RedirectToRouteResult(new RouteValueDictionary
                      {{"Action", "Index"},{"Controller", "Home" }, {"Area", ""}, {"returnUrl", url}});
                }
                base.OnActionExecuting(context);
            }
            #endregion
        }

        #endregion  
    }
}
