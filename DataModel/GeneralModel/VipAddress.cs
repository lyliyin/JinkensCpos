namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VipAddress")]
    public partial class VipAddress
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string Province { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Town { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        public int? IsDefault { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string PostCode { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
    }
}
