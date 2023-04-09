using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab1.Models
{
    public class GasStation
    {
         
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public string Address { get; set; }
        public string OwnerCompany { get; set; }
        public string GasolineStocks { get; set; }
        public string PriceOfBrandGasoline { get; set; }

    }
}
