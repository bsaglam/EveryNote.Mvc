using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryNote.Entities.ViewModels
{
    public class EditUserViewModel
    {
        public int Id { get; set; }
        [DisplayName("Adınız")]
        public string FirstName { get; set; }

        [DisplayName("soyadınız")]
        public string LastName { get; set; }

        [DisplayName("Kullanıcı Adınız"),Required]
        public string UserName { get; set; }

        [DisplayName("Mail Adresiniz"), Required]
        public string EMail { get; set; }

        [DisplayName("Şifreniz"), Required]
        public string Password { get; set; }

        [DisplayName("Profil Fotografı")]
        public string ImageFilePath { get; set; }
    }
}
