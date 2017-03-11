using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AXIS.Models
{
    public class Ccall
    {

        public virtual int CcallId { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "The title is required.")]
        public virtual string Title { get; set; }

        [DisplayName("Date")]
        [Required(ErrorMessage = "The date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public virtual DateTime Date { get; set; }

        [DisplayName("Note")]
        [Required(ErrorMessage = "The note is required.")]
        public virtual string Note { get; set; }


        [DisplayName("User Name")]
        [Required(ErrorMessage = "The user name is required.")]
        public virtual string UserName { get; set; }

        public virtual int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}