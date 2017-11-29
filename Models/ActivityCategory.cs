using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ass2.Models
{
    public partial class ActivityCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActivityCategoryId { get; set; }

        public string ActivityDescription { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual List<Event> Events { get; set; }
    }
}
