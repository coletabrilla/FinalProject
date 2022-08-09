using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DataModel
{
    public class Product
    {
        public int? ID { get; set; } //take note

        public string? Stock { get; set; }

        public string? Type { get; set; }

        public int? Price { get; set; }

        public int? Qty { get; set; }

        public string? Supplier { get; set; }

        public DateTime? DateStocked { get; set; } = DateTime.Now;


    }
}
