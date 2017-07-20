using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AXIS.Models
{
    [Table("ToolType")]
    public class ToolType
    {
        public virtual int ToolTypeId { get; set; }

        [DisplayName("DESCRIPTION")]
        [Required(ErrorMessage = "The description is required.")]
        public virtual string Description { get; set; }

    }
}