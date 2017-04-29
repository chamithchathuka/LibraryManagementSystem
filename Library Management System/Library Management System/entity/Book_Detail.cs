namespace Library_Management_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book_Detail
    {
        [Key]
        public int book_id { get; set; }

        [StringLength(50)]
        public string book_no { get; set; }

        [StringLength(50)]
        public string title { get; set; }

        [StringLength(50)]
        public string author { get; set; }

        [StringLength(50)]
        public string category { get; set; }

        [StringLength(50)]
        public string publisher { get; set; }

        [StringLength(50)]
        public string language { get; set; }

        [StringLength(50)]
        public string isbn { get; set; }

        [StringLength(50)]
        public string year { get; set; }

        [StringLength(50)]
        public string pages { get; set; }

        [Column(TypeName = "image")]
        public byte[] image { get; set; }

        public DateTime? date_added { get; set; }

        [StringLength(50)]
        public string type { get; set; }

        [StringLength(50)]
        public string available { get; set; }

        public decimal? price { get; set; }

        [StringLength(500)]
        public string description { get; set; }

        public int? no_of_copies { get; set; }
    }
}
