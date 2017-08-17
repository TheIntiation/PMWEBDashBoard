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
        [HttpPost]
        [Route("api/UserManagement/LoginUserValidation")]
        public HttpResponseMessage LoginUserValidation(LoginDTO LoginDTO)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.UserManagement.LoginUserValidation(LoginDTO.UserName, LoginDTO.Password);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }

        [HttpPost]
        [Route("api/UserManagement/AddUserDeviceDetails")]
        public HttpResponseMessage AddUserDeviceDetails(UserAccount Obj)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.UserManagement.AddUserDeviceDetails(Obj.UserID,Obj.UserName,Obj.IMEI);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }



    }
}
