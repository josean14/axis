using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AXIS.Models
{
    [Table("UserRoles")]
    public class UserRole
    {
        [Key]
        [ForeignKey("User")]
        public virtual string UserId { get; set; }

        public virtual string RoleId { get; set; }

        public User User { get; set; }
    }
}