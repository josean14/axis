using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AXIS.Models
{
    public class User
    {

        public virtual string Id { get; set; }

        public virtual string UserName { get; set; }

        public virtual string Email { get; set; }

        public UserRole UserRoles { get; set; }
        
    }
}