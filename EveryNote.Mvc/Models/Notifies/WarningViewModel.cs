using EveryNote.Entities.ErrorManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveryNote.Mvc.Models.Notifies
{
    public class WarningViewModel : NotifyViewModelBase<String>
    {
        public WarningViewModel()
        {
            Header = "Uyarı";
        }
        
    }
}