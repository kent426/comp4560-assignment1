using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithDataLib.Models
{
    class ActivityCategory
    {
        public int ActivityCategoryId { get; set; }
        public string ActivityDescription { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
