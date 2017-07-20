using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AXIS.Models
{
    [Table("Tool")]
    public class Tool
    {

        public virtual int ToolId { get; set; }

        [DisplayName("DESCRIPTION")]
        [Required(ErrorMessage = "The description is required.")]
        public virtual string Description { get; set; }

        [DisplayName("NUMBER ITEM")]
        [Required(ErrorMessage = "The number item is required.")]
        public virtual string NumberItem { get; set; }

        [DisplayName("TOOL TYPE")]
        [Required(ErrorMessage = "The tool type item is required.")]
        public virtual string ToolType { get; set; }

        public virtual string Status { get; set; }


    }
}