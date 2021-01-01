using EveryNote.DataAccessLayer;
using EveryNote.DataAccessLayer.EntityFramework;
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

        public void SinglettonPattternTest()
        {
            //farklı dbcontext instance ı ile, database işlemi yapmaya çalışırsak hata alırız.
            //Burda comment ekleyelim.
            Repository<Comments> comment_repo = new Repository<Comments>();
            Repository<Notes> note_repo = new Repository<Notes>();
            Repository<Users> user_repo = new Repository<Users>();

            Notes note = note_repo.Find(x => x.Id == 3);
            Users user = user_repo.Find(x => x.Id == 2);
            Comments comment = new Comments()
            {
                CreatedOn=DateTime.Now,
                ModifiedOn=DateTime.Now,
                ModifiedUser="bsaglam",
                Text="abankldfsşdfösşlfşsdlfldsöc",
                Note=note,
                User=user
            };

            comment_repo.Insert(comment);
        }
    }
}
