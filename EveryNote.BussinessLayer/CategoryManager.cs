using EveryNote.DataAccessLayer.EntityFramework;
using EveryNote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryNote.BussinessLayer
{
    public class CategoryManager
    {
        Repository<Categories> repo = new Repository<Categories>();
        public List<Categories> ListCategories()
        {
            return repo.List();
        }
    }
}
