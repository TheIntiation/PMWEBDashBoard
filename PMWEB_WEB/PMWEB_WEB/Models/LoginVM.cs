using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMWEB_WEB.Models
{
      public class LoginVM
    {
        public UserAccount LoggedUser { get; set; }
        public string SysPassword { get; set; }
        public string ValideMessage { get; set; }
        public bool Failed { get; set; }

        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }

        public String Validate()
        {
            if (this.LoggedUser.UserName == null && this.SysPassword == null)
            {
                return "Please Enter The UserName And Password";
            }
            if (this.LoggedUser.UserName == null)
            {
                return "Please Enter The UserName";
            }
            if (this.SysPassword == null)
            {
                return "Please Enter The Password";
            }

            return string.Empty;
        }
    }
}