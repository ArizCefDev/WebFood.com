using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Menu
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
        public Category? Category { get; set; }
    }
}
