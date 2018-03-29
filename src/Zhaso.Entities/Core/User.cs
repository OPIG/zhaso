using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Zhaso.Entities
{
    public class User : RecordEntity
    {
        [Column(Order = 11)]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Column(Order = 12)]
        [Required]
        [MaxLength(50)]
        public string LoginName { get; set; }
        [Column(Order = 13)]
        [MaxLength(20)]
        [JsonIgnore]
        public string Password { get; set; }
        [Column(Order = 14)]
        [MaxLength(50)]
        public string Email { get; set; }
        [Column(Order = 15)]
        [MaxLength(50)]
        public string Phone { get; set; }
        [Column(Order = 16)]
        [MaxLength(250)]
        public string Photo { get; set; } = "images/user.svg";
        [Column(Order = 17)]
        [Required]
        public Gender Gender { get; set; }
        [Column(Order = 18)]
        public DateTime? Birthday { get; set; }
        [Column(Order = 19)]
        public DateTime? EntryDate { get; set; }
        [Column(Order = 20)]
        public DateTime? LeaveDate { get; set; }
        [Column(Order = 21)]
        [Required]
        public int Status { get; set; }

        public virtual IList<RoleUser> RoleUsers { set; get; }
    }
}
