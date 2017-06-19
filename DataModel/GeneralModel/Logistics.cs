namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Logistics
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string LogisticsName { get; set; }

        [StringLength(50)]
        public string LogisticsCode { get; set; }

        public int? LogisticsStatus { get; set; }

        [StringLength(500)]
        public string LogisticsPayCategory { get; set; }
    }
}
