using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryNote.Entities
{
    [Table("Comments")]
    public class Comments:EntityBase
    {
        [StringLength(1000)]
        public string Text { get; set; }
        public virtual Notes Note { get; set; }
        public virtual Users User { get; set; }
    }
}
