namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string OrderNo { get; set; }

        [StringLength(50)]
        public string VipName { get; set; }

        [StringLength(50)]
        public string VIpId { get; set; }

        [StringLength(50)]
        public string SysCardTypeName { get; set; }

        [StringLength(50)]
        public string SysCardTypeLevelBef { get; set; }

        [StringLength(50)]
        public string SysCardTypeLevelAfe { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? PayDate { get; set; }

        public decimal? UseAmount { get; set; }

        public decimal? UsePoint { get; set; }

        [StringLength(50)]
        public string Discount { get; set; }

        public decimal? ActualAmount { get; set; }

        public decimal? TotalAmount { get; set; }

        [StringLength(50)]
        public string AddressId { get; set; }

        public int? ItemCount { get; set; }

        [StringLength(50)]
        public string OrderStatus { get; set; }

        [StringLength(50)]
        public string UnitId { get; set; }

        [StringLength(50)]
        public string UserId { get; set; }

        [StringLength(50)]
        public string SourcesId { get; set; }

        [StringLength(50)]
        public string CouponId { get; set; }

        [StringLength(50)]
        public string PayMethod { get; set; }
    }
}
