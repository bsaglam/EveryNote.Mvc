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
        public BussinessLayerResult<Users> RegisterUser(RegisterViewModel model)
        {
            //username&email var mı kontrolü
            //yoksa kayıt işlemi
            //activasyon epostası
            BussinessLayerResult<Users> blr = new BussinessLayerResult<Users>();
            //1.Kullanıcı&emial db de varmı kontrolü
            Repository<Users> repo = new Repository<Users>();
            Users user = repo.Find(x=>x.UserName == model.UserName || x.EMail == model.Email);
            if (user != null)
            {
                if (user.UserName == model.UserName)
                {
                    blr.Errors.Add("Bu kullanıcı adı ile kullanıcı zaten bulunmaktadır.");
                }
                if (user.EMail == model.Email)
                {
                    blr.Errors.Add("Bu email ile kullanıcı kaydı bulunmaktadır. ");
                }

            }
            else
            {
                // TODO : insert et
                //insert ettiğin modelin bilgileerini db den getir.
                //activate maili gönder
                int dbResult=repo.Insert(new Users() {
                    EMail=model.Email,
                    Password=model.Password,
                    UserName=model.UserName
                });
                if (dbResult>0)
                {
                    Users result = repo.Find(x => x.UserName == model.UserName && x.EMail == model.Email);
                    blr.Model = result;

                    // TODO : Aktivasyon aili gönderilecek.
                }
            }
            return blr;
        }
    }
}
