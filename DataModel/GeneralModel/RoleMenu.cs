namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoleMenu")]
    public partial class RoleMenu
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string RoleId { get; set; }

        [StringLength(50)]
        public string MenuId { get; set; }
    }
}
