using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveryNote.Mvc.Models.Notifies
{
    public class SuccessViewModel : NotifyViewModelBase<String>
    {
        public SuccessViewModel()
        {
            Header = "Başarılı";
        }
    }
}