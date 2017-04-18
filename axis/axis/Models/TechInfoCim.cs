using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AXIS.Models
{
    [Table("TechInfoCims")]
    public class TechInfoCim
    {
        public virtual int TechInfoCimId { get; set; }

        [DisplayName("Computer")]
        public virtual string Computer { get; set; }

        [DisplayName("Phone")]
        public virtual string Phone { get; set; }

        [DisplayName("Camera")]
        public virtual string Camera { get; set; }

        [DisplayName("Other")]
        public virtual string Other { get; set; }

        [DisplayName("Tech")]
        public virtual int TechId { get; set; }

        public virtual Tech Tech { get; set; }

    }
}