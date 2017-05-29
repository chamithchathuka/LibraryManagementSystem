namespace Library_Management_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Member_Detail
    {
        [Key]
        public int member_id { get; set; }

        [StringLength(50)]
        public string first_name { get; set; }

        [StringLength(50)]
        public string last_name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dob { get; set; }

        [StringLength(100)]
        public string admission_number { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(200)]
        public string address { get; set; }

        [StringLength(100)]
        public string phone_number { get; set; }

        [Column(TypeName = "image")]
        public byte[] photo { get; set; }
    }
}
