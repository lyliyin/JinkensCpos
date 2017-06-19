namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string UserCode { get; set; }

        [StringLength(50)]
        public string UserPhone { get; set; }

        [StringLength(50)]
        public string UserEmail { get; set; }

        public int? UserStatus { get; set; }
    }
}
