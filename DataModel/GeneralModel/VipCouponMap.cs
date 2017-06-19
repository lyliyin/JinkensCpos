namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VipCouponMap")]
    public partial class VipCouponMap
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string VipId { get; set; }

        [StringLength(50)]
        public string CouponId { get; set; }

        public int? VipCouponStatus { get; set; }

        public int? IsUse { get; set; }

        [StringLength(50)]
        public string OrderId { get; set; }
    }
}
