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
    public class UserManagementController : ApiController
    {
        [HttpPost]
        [Route("api/UserManagement/LoginUserValidation")]
        public HttpResponseMessage LoginUserValidation(string UserName, string Password)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.UserManagement.LoginUserValidation(UserName, Password);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }

    }
}
