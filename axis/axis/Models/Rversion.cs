using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        [DisplayName("Scope Work")]
        public virtual int ScopeWorkId { get; set; }

        [AllowHtml]
        [DisplayName("Terms & Conditions")]
        [Required(ErrorMessage = "The Terms & conditions is required.")]
        public virtual string TermsandConditions { get; set; }


        [DisplayName("MIPricePerTech")]
        public virtual double MIPricePerTech { get; set; }

        [DisplayName("MITechnicians")]
        public virtual double MITechnicians { get; set; }

        [DisplayName("MITotal")]
        public virtual double MITotal { get; set; }

        [DisplayName("MOPricePerTech")]
        public virtual double MOPricePerTech { get; set; }

        [DisplayName("MOTechnicians")]
        public virtual double MOTechnicians { get; set; }

        [DisplayName("MOTotal")]
        public virtual double MOTotal { get; set; }

        public virtual Rfq Rfq { get; set; }

        public virtual ScopeWork ScopeWork { get; set; }

        public virtual List<Quote> Qoutes { get; set; }
    }
}