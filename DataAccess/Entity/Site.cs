using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Site
    {
        public int ID { get; set; }
        public string? LogoImageURL { get; set; }
        public string? BannerImageURL { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
    }
}
