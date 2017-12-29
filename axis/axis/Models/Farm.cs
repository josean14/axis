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

        [DisplayName("TYPE OF SITE")]
        [Required(ErrorMessage = "The type of farm is required.")]
        public virtual TypeFarm? TypeFarm { get; set; }

        [DisplayName("SITE NAME")]
        [Required(ErrorMessage = "The farm name is required.")]
        public virtual string FarmName { get; set; }


        [DisplayName("STREET ADDRESS")]
        [Required(ErrorMessage = "The street address is required.")]
        public virtual string StreetAddress { get; set; }

        [DisplayName("CITY")]
        [Required(ErrorMessage = "The city is required.")]
        public virtual string City { get; set; }

        [DisplayName("STATE")]
        [Required(ErrorMessage = "The state is required.")]
        public virtual string State { get; set; }

        [DisplayName("ZIP CODE")]
        [Required(ErrorMessage = "The zipcode is required.")]
        public virtual string ZipCode { get; set; }

        [DisplayName("COUNTRY")]
        [Required(ErrorMessage = "The country is required.")]
        public virtual string Country { get; set; }

        [DisplayName("MANUFACTURE")]
        public virtual string Manufacture { get; set; }

        [DisplayName("PLATFORM")]
        public virtual string Platform { get; set; }

        [DisplayName("CONVERTOR")]
        public virtual string Convertor { get; set; }

        [DisplayName("# OF TOWERS")]
        public virtual int NumberTowers { get; set; }

        [DisplayName("MW")]
        public virtual double NumberMws { get; set; }

        [DisplayName("GEARBOX")]
        public virtual string Gearbox { get; set; }

        [DisplayName("# OF PANELS")]
        public virtual string Panel { get; set; }

        [DisplayName("ID Client")]
        public virtual int ClientId { get; set; }

        [DisplayName("CUSTOMER")]
        public virtual Client Client { get; set; }
        

        public virtual ICollection<Rfq> Rfqs { get; set; }

        [DisplayName("GEOLONG")]
        [Required(ErrorMessage = "GeoLong is required.")]
        public virtual double GeoLong { get; set; }

        [DisplayName("GEOLAT")]
        [Required(ErrorMessage = "The GeoLat is required.")]
        public virtual double GeoLat { get; set; }


        [DisplayName("E-MAIL")]
        [Required(ErrorMessage = "The email is required.")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$",
            ErrorMessage = "Invalid email address.")]
        public virtual string Email { get; set; }
    }
}