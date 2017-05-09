using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AXIS.Models
{
    public class Contract
    {
        public virtual int ContractId { get; set; }

        [DisplayName("Comments")]
        public virtual string Comments { get; set; }

        //[DisplayName("Date")]
        //[Required(ErrorMessage = "The date is required.")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public virtual DateTime Date { get; set; }

        [DisplayName("File")]
        public virtual string File { get; set; }

        [DisplayName("Start Contract")]
        [Required(ErrorMessage = "The date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public virtual DateTime StartDate { get; set; }

        [DisplayName("End Contract")]
        [Required(ErrorMessage = "The date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public virtual DateTime EndDate { get; set; }

        [DisplayName("Status")]
        public virtual string Status { get; set; }

        public virtual int RfqId { get; set; }

        public virtual int RversionId { get; set; }

        public virtual Rfq Rfq { get; set; }
        public virtual Rversion Rversion { get; set; }
    }
}