using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AXIS.Models
{

    public enum TypeWork
    {
        Services, Construct
    }

    public class Rversion
    {

        public virtual int RversionId { get; set; }



        public virtual int NumberVersion { get; set; }


        public virtual DateTime Date { get; set; }

        [DisplayName("Type work")]
        public virtual TypeWork? TypeWork { get; set; }

        [Required(ErrorMessage = "The Sope Work is required.")]
        public virtual string ScopeWork { get; set; }

        [DisplayName("Project description")]
        [Required(ErrorMessage = "The project description is required.")]
        public virtual string ProjectDescription { get; set; }

        [DisplayName("Total cost")]
        public virtual double TotalCost { get; set; }

        [DisplayName("Status")]
        public virtual string Status { get; set; }

        [Required(ErrorMessage = "The notes and instructions is required.")]
        public virtual String NotesAndInstructions { get; set; }

        [DisplayName("Number Project")]
        public virtual int RfqId { get; set; }

        public virtual Rfq Rfq { get; set; }
        public virtual List<Qoute> Qoutes { get; set; }
    }
}