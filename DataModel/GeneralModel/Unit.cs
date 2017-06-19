namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Unit")]
    public partial class Unit
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string UnitName { get; set; }

        [StringLength(50)]
        public string UnitCode { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(11)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Pid { get; set; }
    }
}
