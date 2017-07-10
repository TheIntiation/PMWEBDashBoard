using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMWEB_WEB.Models;
using DataModel;
using PMWEB_WEB.Helper;


namespace PMWEB_WEB.Controllers
{
    //[SessionSecurity]
    public class HomeController : Controller
    {
        const string CONST_ViewName = "Login";

        public ActionResult Index()
        {
            ViewBag.ServiceUrl = ConfigurationReader.GetServiceLayerBaseAddress();
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Title = CONST_ViewName;

            return View(CONST_ViewName, null);
        }


        [HttpPost]
        public ActionResult LogOn(LoginVM model)
        {
            UserAccount loggedInUser = new UserAccount();

            if (ModelState.IsValid)
            {
                model.ValideMessage = model.Validate();

                if (model.ValideMessage != string.Empty)
                {
                    return View(CONST_ViewName, model);
                }
                else
                {
                    DataTransferModel returnValue = new DataTransferModel();
                    returnValue = DAL.UserManagement.LoginUserValidation(model.LoggedUser.UserName, model.SysPassword);
                    if (returnValue.IsSucess == false)
                    {
                        model.ValideMessage = returnValue.Message;
                        return View(CONST_ViewName, model);
                    }
                    else
                    {
                        Session.RemoveAll();
                        //UserAccount loggedInUser = returnValue.DataValue;
                        Session["CurrentUser"] = returnValue.DataValue;
                        Session["UserID"] = returnValue.DataValue.UserID;
                        Session["UserName"] = returnValue.DataValue.UserName;
                        Session["UserFullName"] = returnValue.DataValue.UserFullName;

                        return RedirectToAction("Index", "Home");

                    }
                }
            }
            else
            {
                return View(CONST_ViewName, model);
            }
        }
        public ActionResult LogOut()
        {
            Session.RemoveAll();
            Session["CurrentUser"] = null;
            Session["UserID"] = null;
            Session["UserName"] = null;
            Session["UserFullName"] = null;

            return View(CONST_ViewName, null);
        }

    }
}