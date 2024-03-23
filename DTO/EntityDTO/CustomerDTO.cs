using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.EntityDTO
{
    public class CustomerDTO
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? imageURL { get; set; }
        public string? Text { get; set; }
        public string? Rate { get; set; }
    }
}
