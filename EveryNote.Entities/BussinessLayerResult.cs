using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryNote.Entities
{
    public class BussinessLayerResult<T> where T : class
    {
        public List<string> Errors { get; set; }

        public T Model { get; set; }


        public BussinessLayerResult()
        {
            Errors = new List<string>();
        }
    }
}
