using EveryNote.DataAccessLayer;
using EveryNote.Entities;
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
            //DataBaseContext db = new DataBaseContext();
            ////db.Database.CreateIfNotExists();
            //db.Categories.ToList();
            Repository<Categories> categoriRepo = new Repository<Categories>();
            List<Categories> result=categoriRepo.List();
        }
    }
}
