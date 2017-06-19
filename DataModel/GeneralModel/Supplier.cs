namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    public partial class Supplier
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string SupplierName { get; set; }

        [StringLength(50)]
        public string SupplierCode { get; set; }

        public int? SulipperStatus { get; set; }
    }
}
