using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AXIS.Models
{
    [Table("ToolKits")]
    public class ToolKit
    {

        public virtual int ToolKitsId { get; set; }


        [DisplayName("DESCRIPTION")]
        [Required(ErrorMessage = "The description is required.")]
        public virtual string Description { get; set; }

        [DisplayName("NUMBER ITEM")]
        [Required(ErrorMessage = "The number item is required.")]
        public virtual string NumberItem { get; set; }

        [DisplayName("KIT TYPE")]
        [Required(ErrorMessage = "The kit type item is required.")]
        public virtual string KitType { get; set; }

        public virtual string Status { get; set; }

        public virtual List<KitComponent> KitComponents { get; set; }

    }
}