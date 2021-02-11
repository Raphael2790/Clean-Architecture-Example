using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchExample.Application.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage="This Name is Required")]
        [MaxLength(100)]
        [MinLength(3)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="This Description is required")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage ="This Price is required")]
        [Range(1, 99999.99)]
        [DisplayName("Price")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Price { get; set; }
    }
}
