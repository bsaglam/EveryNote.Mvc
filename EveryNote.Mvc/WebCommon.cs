using EveryNote.Common;
using EveryNote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveryNote.Mvc
{
    public class WebCommon : ICommon
    {
        public string GetCurrentUserName()
        {
            Users user = HttpContext.Current.Session["user"] as Users;
            return user.UserName;
        }
    }
}