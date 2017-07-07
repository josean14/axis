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
        WIND, SOLAR, OTHER
    }


    public class Farm
    {
        public virtual int FarmId { get; set; }

        [DisplayName("Type of Farm")]
        [Required(ErrorMessage = "The type of farm is required.")]
        public virtual TypeFarm? TypeFarm { get; set; }

        [DisplayName("Farm Name")]
        [Required(ErrorMessage = "The farm name is required.")]
        public virtual string FarmName { get; set; }


        [DisplayName("Street Address")]
        [Required(ErrorMessage = "The street address is required.")]
        public virtual string StreetAddress { get; set; }

        [DisplayName("City")]
        [Required(ErrorMessage = "The city is required.")]
        public virtual string City { get; set; }

        [DisplayName("State")]
        [Required(ErrorMessage = "The state is required.")]
        public virtual string State { get; set; }

        [DisplayName("Zip Code")]
        [Required(ErrorMessage = "The zipcode is required.")]
        public virtual string ZipCode { get; set; }

        [DisplayName("Country")]
        [Required(ErrorMessage = "The country is required.")]
        public virtual string Country { get; set; }

        [DisplayName("Manufacture")]
        public virtual string Manufacture { get; set; }

        [DisplayName("Platform")]
        public virtual string Platform { get; set; }

        [DisplayName("Convertor")]
        public virtual string Convertor { get; set; }

        [DisplayName("# of Towers")]
        public virtual int NumberTowers { get; set; }

        [DisplayName("MW")]
        public virtual double NumberMws { get; set; }

        [DisplayName("Gearbox")]
        public virtual string Gearbox { get; set; }

        [DisplayName("# of Panels")]
        public virtual string Panel { get; set; }

        [DisplayName("ID Client")]
        public virtual int ClientId { get; set; }

        [DisplayName("Client")]
        public virtual Client Client { get; set; }
        

        public virtual ICollection<Rfq> Rfqs { get; set; }

        [DisplayName("GeoLong")]
        [Required(ErrorMessage = "GeoLong is required.")]
        public virtual double GeoLong { get; set; }

        [DisplayName("GeoLat")]
        [Required(ErrorMessage = "The GeoLat is required.")]
        public virtual double GeoLat { get; set; }


        [DisplayName("E-mail")]
        [Required(ErrorMessage = "The email is required.")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$",
            ErrorMessage = "Invalid email address.")]
        public virtual string Email { get; set; }
    }
}