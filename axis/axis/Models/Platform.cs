using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AXIS.Models
{
    [Table("Platforms")]
    public class Platform
    {

        public virtual int PlatformId { get; set; }

        [DisplayName("Manufactere")]
        [Required(ErrorMessage = "The manufactere is required.")]
        public virtual string ManufacturerName { get; set; }

        [DisplayName("Platform")]
        [Required(ErrorMessage = "The manufactere is required.")]
        public virtual string PlatformName { get; set; }
    }
}