using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryNote.Common
{
    public class DefaultClass : ICommon
    {
        public string GetCurrentUserName()
        {
            return "system";
        }
    }
}
