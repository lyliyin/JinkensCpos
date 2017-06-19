namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Brand")]
    public partial class Brand
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string BrandName { get; set; }

        [StringLength(50)]
        public string BrandCode { get; set; }

        public int? BrandStatus { get; set; }

        [StringLength(100)]
        public string logoImages { get; set; }
    }
}
