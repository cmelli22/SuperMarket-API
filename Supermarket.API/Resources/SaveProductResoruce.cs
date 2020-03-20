using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Resources
{
    public class SaveProductResoruce
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int QuantityInPackage { get; set; }
        [Required]
        public int UnitOfMeasurement { get; set; }
        [Required]
        public int CategoryId { get; set; }

    }
}
