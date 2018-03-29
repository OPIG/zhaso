using System;

namespace Zhaso
{
    using Interfaces;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class RecordEntity : EntityBase, IRecordEntity
    {
        [Column(Order = 1001)]
        public decimal Order { get; set; }
        [Column(Order = 1002)]
        public DateTime CreateTime { get; set; } = DateTime.Now;
        [Column(Order = 1003)]
        public DateTime UpdateTime { get; set; } = DateTime.Now;
        [Column(Order = 1004)]
        [MaxLength(50)]
        public string CreateUser { get; set; } = "N/A";
        [Column(Order = 1005)]
        [MaxLength(50)]
        public string UpdateUser { get; set; } = "N/A";
        [Column(Order = 1006)]
        public bool Deleted { get; set; }
    }
}
