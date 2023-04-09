using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab2.Models
{
    public class GasStation
    {
         
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        [Required]
      
        [RegularExpression(@"^[A-Za-z]*(\s+[A-Za-z]*)*$", ErrorMessage = "The address must contain the region, district, settlement, address")]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^\""([A-Z][a-z]\""*$", ErrorMessage = "The name must be in quotes and start with a capital letter")]
        public string OwnerCompany { get; set; }

        [Required]
        [RegularExpression("^[1-9]*$", ErrorMessage = "The number must be a positive integer")]
        public string GasolineStocks { get; set; }

        [Required]
        [RegularExpression("^([0-9]*[.])?[0-9]*$", ErrorMessage = "The number must be a positive real number")]
        public string PriceOfBrandGasoline { get; set; }

    }
}
