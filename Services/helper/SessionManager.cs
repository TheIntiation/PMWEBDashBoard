using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.helper
{
    public static class SessionManager
    {
        public static void AddSessionObject(string key, object sessionObject)
        {
            if (HttpContext.Current.Session[key] == null)
            {
                HttpContext.Current.Session.Add(key, sessionObject);
            }
            else
            {
                HttpContext.Current.Session[key] = sessionObject;
            }
        }

        public static object GetSessionObject(string key)
        {
            return HttpContext.Current.Session[key];
        }
    }
}