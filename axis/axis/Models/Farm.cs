using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AXIS.Models
{

    public enum TypeFarm
    {
        Wind, Solar, Other
    }


    public class Farm
    {
        public virtual int FarmId { get; set; }

        [DisplayName("Type of farm")]
        [Required(ErrorMessage = "The type of farm is required.")]
        public virtual TypeFarm? TypeFarm { get; set; }

        [DisplayName("Farm name")]
        [Required(ErrorMessage = "The farm name is required.")]
        public virtual string FarmName { get; set; }


        [DisplayName("Street address")]
        [Required(ErrorMessage = "The street address is required.")]
        public virtual string StreetAddress { get; set; }

        [Required(ErrorMessage = "The city is required.")]
        public virtual string City { get; set; }

        [Required(ErrorMessage = "The state is required.")]
        public virtual string State { get; set; }

        [Required(ErrorMessage = "The zipcode is required.")]
        public virtual string ZipCode { get; set; }

        [Required(ErrorMessage = "The country is required.")]
        public virtual string Country { get; set; }
        public virtual string Manufacture { get; set; }
        public virtual string Platform { get; set; }
        public virtual string Convertor { get; set; }
        public virtual int NumberTowers { get; set; }
        public virtual int NumberMws { get; set; }
        public virtual string Gearbox { get; set; }
        public virtual int ClientId { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<Rfq> Rfqs { get; set; }

    }
}