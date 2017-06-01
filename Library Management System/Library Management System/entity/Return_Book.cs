namespace Library_Management_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Return_Book
    {
        [Key]
        public int return_id { get; set; }

        public int? book_id { get; set; }

        public int? issue_id { get; set; }

        public int? member_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? issue_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? due_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? submited_date { get; set; }

        public double? fine { get; set; }

        [MaxLength(10)]
        public byte[] fine_paid { get; set; }
    }
}
