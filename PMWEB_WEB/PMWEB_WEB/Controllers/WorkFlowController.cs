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
    public class WorkFlowController : Controller
    {
        //
        // GET: /WorkFlow/
        public ActionResult Index()
        {
            ViewBag.ServiceUrl = ConfigurationReader.GetServiceLayerBaseAddress();
            return View();
        }

        public ActionResult WorkFlowDetail()
        {
            ViewBag.ServiceUrl = ConfigurationReader.GetServiceLayerBaseAddress();
            return View();
        }

	}
}