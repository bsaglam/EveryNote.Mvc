using EveryNote.Entities.ErrorManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveryNote.Mvc.Models.Notifies
{
    public class ErrorViewModel : NotifyViewModelBase<ErrorMessage>
    {
        public ErrorViewModel()
        {
            Notifies = new List<ErrorMessage>();

            Notifies.Add(new ErrorMessage()
            {
                ErrorCode = ErrorMessageCode.SomethingIsWrong,
                Message ="Bir şeyler ters gitti."
            });

        }
    }
}