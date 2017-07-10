using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataModel;
using System.Web.Routing;


namespace PMWEB_WEB.Controllers
{

    public class SessionSecurityAttribute : ActionFilterAttribute
    {
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            var actionName = filterContext.RequestContext.HttpContext.Request["Action"];
            if (actionName == null)
            {
                actionName = filterContext.ActionDescriptor.ActionName;           
            }
            //Case for Login and Main page access
            if ((controllerName == "Home")
                                        && (actionName == "Login" || 
                                            actionName == "LogOn" || 
                                            actionName == "LogOut" ||
                                            actionName == "Logout" ||
                                            actionName == "Main" ||
                                            actionName == "CheckLogOutStatus"))
            {
                //OK for these functions
                return;
            }

            UserAccount currentUserInSession = (UserAccount)filterContext.HttpContext.Session["CurrentUser"];

            if (currentUserInSession == null) //Session checking for Logged in user
            {
                SetLoginRedirectURL(filterContext);
                filterContext.Controller.TempData["Message"] = "انتهت الفترة المتاحة لاستخدامك النظام. برجاء إعادة الدخول" + Environment.NewLine + "Your session has expired . Please Login again";
                return;
            }

        }

        private void SetLoginRedirectURL(ActionExecutingContext filterContext)
        {
            RouteValueDictionary redirectTargetDictionaryLogin = new RouteValueDictionary();
            redirectTargetDictionaryLogin.Add("controller", "Home");
            redirectTargetDictionaryLogin.Add("action", "Login");
            filterContext.Result = new RedirectToRouteResult(redirectTargetDictionaryLogin);
        }


       
    }
    
}