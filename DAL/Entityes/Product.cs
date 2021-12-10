using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entityes
{
    public class Product
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Color { get; set; }
        public string Form { get; set; }
        public int Weight { get; set; }
        public int Price { get; set; }
    }
}
