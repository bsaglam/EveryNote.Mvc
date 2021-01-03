using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryNote.Entities.ErrorManager
{
    public class ErrorMessage
    {
        public ErrorMessageCode ErrorCode { get; set; }

        public string Message { get; set; }
    }
}
