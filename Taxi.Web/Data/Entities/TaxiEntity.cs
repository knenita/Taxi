using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taxi.Web.Data.Entities
{
    public class TaxiEntity
    {
        public int Id { get; set; }

        [RegularExpression(@"^([A-Za-z]{3}\d{3})$", ErrorMessage = "The field {0} must have three characters and ends with three numbers.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "The field {0} must starts with three characters {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Plaque { get; set; }

        //relacion lado uno
        public ICollection<TripEntity> Trips { get; set; }
        //relacion lado muchos - opcional
        public UserEntity User { get; set; }
    }
}