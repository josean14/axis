using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AXIS.Models
{

    [Table("Roles")]
    public class Role
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

    }
}