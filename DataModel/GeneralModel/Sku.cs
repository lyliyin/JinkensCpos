namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sku")]
    public partial class Sku
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string SkuName { get; set; }

        [StringLength(50)]
        public string SkuCode { get; set; }

        [StringLength(50)]
        public string pid { get; set; }
    }
}
