using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AXIS.Models
{
    public class Quote
    {
        public virtual int QuoteId { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "The description is required.")]
        public virtual string Description { get; set; }

        [DisplayName("Price Per Unit")]
        public virtual double PricePerUnit { get; set; }

        [DisplayName("# of Units")]
        public virtual double NUnits { get; set; }

        [DisplayName("Hourly Rate")]
        public virtual double HourlyRate { get; set; }

        [DisplayName("# Technicians")]
        public virtual double Technicians { get; set; }

        [DisplayName("Weekly Hours")]
        public virtual double WeeklyHours { get; set; }

        [DisplayName("# Weeks")]
        public virtual double Weeks { get; set; }

        [DisplayName("Total")]
        public virtual double Total { get; set; }

        //Guardara 1 para horas y 2 para proyecto
        public virtual double TypeR { get; set; }

        public virtual int RversionId { get; set; }

        public virtual Rversion Rversion { get; set; }

    }
}