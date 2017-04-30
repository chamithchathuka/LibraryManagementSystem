namespace Library_Management_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Detail
    {
        [Key]
        [StringLength(1000)]
        public string user_name { get; set; }

        [StringLength(5000)]
        public string password { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string address { get; set; }

        [StringLength(50)]
        public string phone_number { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string type { get; set; }
    }
}
