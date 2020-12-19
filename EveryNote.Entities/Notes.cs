using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryNote.Entities
{
    [Table("Notes")]
    public class Notes :EntityBase
    {
        [Required,StringLength(200)]
        public string Title { get; set; }

        [Required, StringLength(2000)]
        public string Description { get; set; }
        public bool IsDraft { get; set; }
        public int LikeCounts { get; set; }
        public int CategoryId { get; set; }
        public virtual Categories Category { get; set; }
        public virtual Users User { get; set; }
        public virtual List<Comments> Comments { get; set; }
        public virtual List<Liked> Likes { get; set; }
    }
}
