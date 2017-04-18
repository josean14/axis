using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AXIS.Models
{
    public enum TypeOfService
    {
        Service,
        Construction
    }
    [Table("TechInfoWorks")]
    public class TechInfoWork
    {
        public virtual int TechInfoWorkId { get; set; }

        [DisplayName("Type of Service")]
        [Required(ErrorMessage = "The type of service is required.")]
        public virtual TypeOfService? TypeOfService { get; set; }

        [DisplayName("Manufactere")]
        [Required(ErrorMessage = "The manufactere is required.")]
        public virtual string ManufacturerName { get; set; }

        [DisplayName("Platform")]
        [Required(ErrorMessage = "The manufactere is required.")]
        public virtual string PlatformName { get; set; }

        [DisplayName("Notes")]
        [Required(ErrorMessage = "The notes is required.")]
        public virtual string Notes { get; set; }

        [DisplayName("Site Name")]
        [Required(ErrorMessage = "The site name is required.")]
        public virtual int FarmId { get; set; }


        [DisplayName("Sope Work")]
        [Required(ErrorMessage = "The scope work is required.")]
        public virtual int ScopeWorkId { get; set; }

        [DisplayName("Tech")]
        [Required(ErrorMessage = "The tech is required.")]
        public virtual int TechId { get; set; }


        public virtual Tech Tech { get; set; }
        public virtual Farm Farm { get; set; }
        public virtual ScopeWork Scopework { get; set; }

    }
}