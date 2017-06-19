namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrdersDetail")]
    public partial class OrdersDetail
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string OrderId { get; set; }

        [StringLength(50)]
        public string ItemId { get; set; }

        [StringLength(50)]
        public string PriceId { get; set; }

        public decimal? BuyPrice { get; set; }

        public int? BuyCount { get; set; }

        public decimal? ActualAmount { get; set; }

        public decimal? Discount { get; set; }

        public decimal? TotalAmount { get; set; }
    }
}
