using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.GeneralModel
{
    public partial class CouponCategory
    {
        [NotMapped()]
        public string CouponId { get; set; }
    }
}
