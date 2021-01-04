using EveryNote.Common.Helpers;
using EveryNote.DataAccessLayer.EntityFramework;
using EveryNote.Entities;
using EveryNote.Entities.ErrorManager;
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
                    blr.AddError(ErrorMessageCode.UserIsAlreadyExist,"Bu kullanıcı adı ile bir hesap bulunmaktadır.");
                }
                if (user.EMail == model.Email)
                {
                    blr.AddError(ErrorMessageCode.EmailIsAlreadyExist, "Bu Email ile bir hesap bulunmaktadır.");
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
                    UserName=model.UserName,
                    GuidId=Guid.NewGuid(),
                    IsActive=false,
                    IsAdmin=false
                });
                if (dbResult>0)
                {
                    Users result = repo.Find(x => x.UserName == model.UserName && x.EMail == model.Email);
                    blr.Model = result;

                    // TODO : Aktivasyon maili gönderilecek.
                    string rootUri = ConfigHelper.GetConfig<string>("rootUri");
                    Guid guidId = blr.Model.GuidId;
                    string uri = $"{rootUri}/Home/ActivateUser/{guidId}";
                    string body = $" Merhaba, </br> {blr.Model.UserName} </br> Hesabınızı <a href='{uri}'> linke </a> tıklayarak aktifleştiriniz";
                    MailHelper.SendMail(body,blr.Model.EMail,"Hesap aktifleştirme");
                }
            }
            return blr;
        }




        public BussinessLayerResult<Users> LoginUser(LoginViewModel model)
        {
            BussinessLayerResult<Users> blr = new BussinessLayerResult<Users>();
            Repository<Users> repo = new Repository<Users>();
            blr.Model = repo.Find(x=>x.EMail==model.Email && x.Password==model.Password);
            if (blr.Model != null)
            {
                if (!blr.Model.IsActive)
                {
                    blr.AddError(ErrorMessageCode.AccountIsNotActive, "Kullanıcı hesabı aktif değil.");
                }
               
            }
            else
            {
                blr.AddError(ErrorMessageCode.EmailOrPasswordWrong, "Kullanıcı adı veya şifre hatalı.");
            }
            
            return blr;
        }


        public BussinessLayerResult<Users> ActivateUser(Guid id)
        {
            BussinessLayerResult<Users> result = new BussinessLayerResult<Users>();
            Repository<Users> repository = new Repository<Users>();
            result.Model=repository.Find(x => x.GuidId == id);
            if (result.Model != null && !result.Model.IsActive)
            {   
                result.Model.IsActive = true;
                repository.Update(result.Model);
            }
            else
            {
                result.AddError(ErrorMessageCode.ActivateIdDoesNotExist,"Aktifleştirilecek kullanıcı bulunamadı.");
            }
            return result;
        }
    }


}
