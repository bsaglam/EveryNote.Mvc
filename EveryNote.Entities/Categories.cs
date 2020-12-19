using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryNote.Entities
{
    [Table("Categories")]
    public class Categories :EntityBase
    {
        [Required,StringLength(50)]
        public string Title { get; set; }

        [Required, StringLength(100)]
        public string Description { get; set; }
        public virtual List<Notes> Notes { get; set; }
        public Categories()
        {
            Notes = new List<Notes>();
        }
    }
}
