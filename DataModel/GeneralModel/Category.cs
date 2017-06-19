namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(50)]
        public string CategoryCode { get; set; }

        public int? CategoryStatus { get; set; }

        [StringLength(50)]
        public string Pid { get; set; }
    }
}
