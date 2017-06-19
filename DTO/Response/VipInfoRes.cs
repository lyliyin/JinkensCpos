using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class VipInfoRes
    {

        public string Id { get; set; }

        public string VipName { get; set; }


        public string VipPhone { get; set; }
        
        public string VipEmail { get; set; }


        public string VipOnLineId { get; set; }

        public int? VipOnLineCategory { get; set; }

        public int? VipSourceId { get; set; }

        public int? VipPoints { get; set; }

        public decimal? VipAmount { get; set; }

        public string SoourceName { get; set; }
    }
}
