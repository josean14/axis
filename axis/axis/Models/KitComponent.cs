using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AXIS.Models
{
    [Table("KitComponents")]
    public class KitComponent
    {

        public virtual int KitComponentsId { get; set; }

        [DisplayName("DESCRIPTION")]
        [Required(ErrorMessage = "The description is required.")]
        public virtual string Description { get; set; }

        [DisplayName("NUMBER ITEM")]
        [Required(ErrorMessage = "The number item is required.")]
        public virtual string NumberItem { get; set; }

        public virtual string Status { get; set; }

        
        public virtual int ToolKitsId { get; set; }

        
        public virtual ToolKit ToolKit { get; set; }
    }
}