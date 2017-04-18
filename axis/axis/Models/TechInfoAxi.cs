using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AXIS.Models
{
    public enum TechnicalLevel
    {
        A, B, C
    }

    public enum YesNo
    {
        No, Yes
    }

    [Table("TechInfoAxis")]
    public class TechInfoAxi
    {
        public virtual int TechInfoAxiId { get; set; }

        
        [DisplayName("Experience Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public virtual DateTime ExperienceDate { get; set; }

        [DisplayName("Osha 10")]
        public virtual string Osha10 { get; set; }

        [DisplayName("First Aid/CPR")]
        public virtual string FirstAidCPR { get; set; }

        [DisplayName("Tower Rescue")]
        public virtual string TowerRescue { get; set; }

        [DisplayName("Confined Space")]
        public virtual string ConfinedSpace { get; set; }

        [DisplayName("NFPA 70 E")]
        public virtual string Nfra70E { get; set; }

        [DisplayName("LOTO")]
        public virtual string Loto { get; set; }

        [DisplayName("Ergonomics")]
        public virtual string Ergonomics { get; set; }

        [DisplayName("Hazcom")]
        public virtual string Hazcom { get; set; }

        [DisplayName("Crane Safety")]
        public virtual string CraneSafety { get; set; }

        [DisplayName("Rigging/Signal Man")]
        public virtual string RiggingSignalMan { get; set; }

        [DisplayName("Fire extinguisher")]
        public virtual string FireExtinguisher { get; set; }

        [DisplayName("Has I9?")]
        public virtual bool HasI9 { get; set; }

        [DisplayName("I9")]
        public virtual string I9File { get; set; }

        [DisplayName("Has W2?")]
        public virtual bool HasW2 { get; set; }

        [DisplayName("W2")]
        public virtual string W2File { get; set; }

        [DisplayName("Has W4?")]
        public virtual bool HasW4 { get; set; }

        [DisplayName("W4")]
        public virtual string W4File { get; set; }

        [DisplayName("Has Applicance Offer?")]
        public virtual bool HasApplicanceOffer { get; set; }

        [DisplayName("Applicance Offer")]
        public virtual string ApplicanceOfferFile { get; set; }

        [DisplayName("Has AXIS labor code?")]
        public virtual bool HasAxisLaborCode { get; set; }

        [DisplayName("AXIS labor code")]
        public virtual string AxisLaborCodeFile { get; set; }

        [DisplayName("Technical Level")]
        public virtual TechnicalLevel? TechnicalLevel { get; set; }

        [DisplayName("Tech")]
        public virtual int TechId { get; set; }

        public virtual Tech Techs { get; set; }

    }
}