using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.EntityDTO
{
    public class MenuDTO
    {
        public int ID { get; set; }
        public string? Image { get; set; }
        public string? Title { get; set; }
        [Range(1, 100)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Range(1, 100)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }
        public string? Gram { get; set; }
        public string? Calori { get; set; }
        public string? Status { get; set; }
        public DateTime Date { get; set; }
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public CategoryDTO? CategoryDTO { get; set; }
    }
}
