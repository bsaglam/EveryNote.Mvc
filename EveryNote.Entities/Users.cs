using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryNote.Entities
{
    public class Users : EntityBase
    {
        [DisplayName("Adı")]
        public string FirstName { get; set; }

        [DisplayName("Soyadı")]
        public string LastName { get; set; }

        [DisplayName("Kullanıcı Adı"),Required, StringLength(50)]
        public string UserName { get; set; }

        [DisplayName("Email"), Required, StringLength(100)]
        public string EMail { get; set; }

        [Required, StringLength(100)]
        public string Password { get; set; }

        [StringLength(50)]
        public string ImageFilePath { get; set; }
        public bool IsActive { get; set; }
        public Guid GuidId { get; set; }
        public bool IsAdmin { get; set; }

        public virtual List<Notes> Notes { get; set; }
        public virtual List<Comments> Comments { get; set; }
        public virtual List<Liked> Likes { get; set; }

        
    }
}
