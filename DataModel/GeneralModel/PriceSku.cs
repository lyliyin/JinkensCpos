namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PriceSku")]
    public partial class PriceSku
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string PriceId { get; set; }

        [StringLength(50)]
        public string SkuId { get; set; }
    }
}
