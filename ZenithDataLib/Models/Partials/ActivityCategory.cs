using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ZenithDataLib.Models
{

    [MetadataType(typeof(ActivityCategoryMetaData))]
    public partial class ActivityCategory { }

    public class ActivityCategoryMetaData
    {
        [HiddenInput(DisplayValue = false)]
        public int ActivityCategoryId { get; set; }

        [Required(ErrorMessage = "Activity Description is required.")]
        [Display(Name = "Activity Description")]
        public string ActivityDescription { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreationDate { get; set; }
    }
}
