using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ItemRes
    {
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public int StoreCount { get; set; }

    }
}
