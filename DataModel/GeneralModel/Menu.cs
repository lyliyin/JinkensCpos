namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string MenuName { get; set; }

        [StringLength(50)]
        public string MenuCode { get; set; }

        [StringLength(50)]
        public string Pid { get; set; }

        public int? MenuStatus { get; set; }
    }
}
