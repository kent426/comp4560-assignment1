using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ZenithDataLib.Models
{

    [MetadataType(typeof(EventMetaData))]
    public partial class Event { }

    public class EventMetaData
    {
        [HiddenInput(DisplayValue = false)]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Event start date is required.")]
        [Display(Name = "Event From")]
        public DateTime EventFromDateTime { get; set; }

        [Required(ErrorMessage = "Event end date is required.")]
        [Display(Name = "Event From")]
        public DateTime EventToDateTime { get; set; }

        [ScaffoldColumn(false)]
        public String EnteredByUsername { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}
