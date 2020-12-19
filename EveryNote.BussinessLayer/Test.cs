using EveryNote.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryNote.BussinessLayer
{
    public class Test
    {
        public Test()
        {
            DataBaseContext db = new DataBaseContext();
            //db.Database.CreateIfNotExists();
            db.Categories.ToList();
        }
    }
}
