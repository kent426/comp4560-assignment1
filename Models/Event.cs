using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ass2.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public partial class Event
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }

        [ValidDate]
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