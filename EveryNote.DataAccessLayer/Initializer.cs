using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EveryNote.Entities;

namespace EveryNote.DataAccessLayer
{
    public class Initializer :CreateDatabaseIfNotExists<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            //burada database oluştuktan sonra tabloya eklemek istediğimiz dataları yazarız.

            Users admin = new Users()
            {
                UserName="bsaglam",
                CreatedOn=DateTime.Now,
                EMail="burcu.saglam001@gmail.com",
                FirstName="burcu",
                IsActive=true,
                IsAdmin=true,
                LastName="sağlam",
                Password="Qs159159",
                ModifiedOn=DateTime.Now.AddMinutes(5),
                ModifiedUser="bsaglam",
                GuidId=Guid.NewGuid()
            };
            Users standartUser = new Users()
            {
                UserName = "bsaglam",
                CreatedOn = DateTime.Now,
                EMail = "burcu.saglam001@gmail.com",
                FirstName = "burcu",
                IsActive = true,
                IsAdmin = true,
                LastName = "sağlam",
                Password = "Qs159159",
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUser = "bsaglam",
                GuidId = Guid.NewGuid()
            };

            context.Users.Add(admin);
            context.Users.Add(standartUser);
            context.SaveChanges();

            //Kategori ekleme
            for (int i = 0; i < 10; i++)
            {
                Categories cat = new Categories()
                {
                    Title = FakeData.PlaceData.GetStreetName(),
                    CreatedOn = DateTime.Now,
                    Description = FakeData.PlaceData.GetStreetName(),
                    ModifiedOn = DateTime.Now.AddMinutes(5),
                    ModifiedUser="bsaglam"

                };

                //kategoriye ait olan notları ekleyelim
                for (int j = 0; j < FakeData.NumberData.GetNumber(0,5); j++)
                {
                    Notes note = new Notes()
                    {
                        ModifiedUser=(j%2==0 ? admin.UserName : standartUser.UserName),
                        User= (j % 2 == 0 ? admin : standartUser),
                        Category=cat,
                        CreatedOn=DateTime.Now,
                        Description=FakeData.TextData.GetSentences(3),
                        ModifiedOn=DateTime.Now,
                        IsDraft=false,
                        LikeCounts=5,
                        Title=FakeData.TextData.GetSentence()
                    };
                    cat.Notes.Add(note);
                }
            }
        }
    }
}
