using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveryNote.Mvc.Models.Notifies
{
    public class NotifyViewModelBase<T>
    {
        public string Title { get; set; }

        public string Header { get; set; }

        public bool IsRedirecting { get; set; }

        public List<T> Notifies { get; set; }

        public int RedirectingTime { get; set; }

        public string RedirectingUri { get; set; }

        public NotifyViewModelBase()
        {
            Title = "yönlendiriliyorsunuz";

            IsRedirecting = true;

            RedirectingTime = 3000;

            RedirectingUri = "/Home/Index";

            Notifies = new List<T>();
        }
    }
}