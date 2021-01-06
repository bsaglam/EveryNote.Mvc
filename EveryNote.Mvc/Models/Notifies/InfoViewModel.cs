using EveryNote.Entities.ErrorManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveryNote.Mvc.Models.Notifies
{
    public class InfoViewModel : NotifyViewModelBase<String>
    {
        public InfoViewModel()
        {
            Header = "Bilgilendirme";
        }
    }
}