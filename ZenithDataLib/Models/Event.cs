using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithDataLib.Models
{
    public partial class Event
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }

        public DateTime EventFromDateTime { get; set; }
        public DateTime EventToDateTime { get; set; }
        public String EnteredByUsername { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("ActivityCategoryId")]
        public virtual ActivityCategory ActivityCategory { get; set; }

        public virtual int ActivityCategoryId { get; set; }


    }
}
