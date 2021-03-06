﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AXIS.Models
{

    [Table("assignmentoftoolsbyjobs")]
    public class AssignmentOfToolsByJob
    {

        [Key]
        public virtual int Id { get; set; }

        [DisplayName("MANUFACTURER")]
        public virtual string Manufacturer { get; set; }

        [DisplayName("MODEL")]
        public virtual string Model { get; set; }

        [DisplayName("SERIAL #1")]
        public virtual string Serial1 { get; set; }

        [DisplayName("SERIAL #2")]
        public virtual string Serial2 { get; set; }

        [DisplayName("STATUS")]
        public virtual string Status { get; set; }

        [DisplayName("Calibration Due / Manufact. Date")]
        [Required(ErrorMessage = "The date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public virtual DateTime CDMD { get; set; }
        
        [DisplayName("ADDITIONAL INFORMATION 1")]
        public virtual string Additional1 { get; set; }

        [DisplayName("ADDITIONAL INFORMATION 2")]
        public virtual string Additional2 { get; set; }

        [DisplayName("LOCATION")]
        public virtual string Location { get; set; }

        [DisplayName("CATEGORY")]
        public virtual string Category { get; set; }

        public virtual int ContractId { get; set; }

  
    }
}