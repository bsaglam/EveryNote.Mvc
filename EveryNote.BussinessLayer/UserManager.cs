using EveryNote.DataAccessLayer.EntityFramework;
using EveryNote.Entities;
using EveryNote.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryNote.BussinessLayer
{
    public class UserManager
    { 
        // burda iş katmanı, UI da olan ViewModel aldı, fakat tanımıyor
        //ozaman ViewModel leri Entities içine koyalım.
        public Users RegisterUser(RegisterViewModel model)
        {
            //username&email var mı kontrolü
            //yoksa kayıt işlemi
            //activasyon epostası
            Repository<Users> userRepo = new Repository<Users>();
            Users user= userRepo.Find(x => x.UserName == model.UserName || x.EMail == model.Email);
            return user;
        }
    }
}
