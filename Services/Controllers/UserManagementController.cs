using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;


namespace Services.Controllers
{
    [EnableCors("*", "*", "*")]
    public class UserManagementController : ApiController
    {
        public  class UserObject {
            public  string UserName { get; set; }
            public  string Password { get; set; }
        }
        [HttpPost]
        [Route("api/UserManagement/LoginUserValidation")]
        public HttpResponseMessage LoginUserValidation(UserObject UserObjectd)
        {
            UserObject obj = new Controllers.UserManagementController.UserObject();
            obj = UserObjectd;
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.UserManagement.LoginUserValidation(obj.UserName, obj.Password);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }

    }
}
