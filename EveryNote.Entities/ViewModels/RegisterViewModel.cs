using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EveryNote.Entities.ViewModels
{
    public class RegisterViewModel
    {
        [DisplayName("Kullanıcı Adı"),Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(50)]
        public string UserName { get; set; }

        [DisplayName("Email"),Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(100),EmailAddress(ErrorMessage ="Geçerli bir E-posta adresi giriniz.")]
        public string Email { get; set; }

        [DisplayName("Şifre"), Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(100)]
        public string Password { get; set; }

        [DisplayName("Şifre (Tekrar)"), Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(100), Compare("Password",ErrorMessage ="{0} ve {1} alanı eşleşmelidir.")]
        public string RePassword { get; set; }
    }
}