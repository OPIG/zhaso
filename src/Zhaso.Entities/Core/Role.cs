using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zhaso.Entities
{
    public class Role : RecordEntity
    {
        [Column(Order = 11)]
        [Required]
        [MaxLength(50)]
        public string RoleName { set; get; }
        [Column(Order = 12)]
        [MaxLength(50)]
        public string SimpleName { set; get; }
        [Column(Order = 13)]
        [MaxLength(500)]
        public string Description { set; get; }

        public virtual IList<RolePermission> RolePermissions { set; get; }
        public virtual IList<RoleUser> RoleUsers { set; get; }
    }
}
