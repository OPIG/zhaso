using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zhaso.Entities
{
    public class Permission : TreeEntity<Permission>
    {
        [Column(Order = 11)]
        [Required]
        [MaxLength(50)]
        public string Name { set; get; }
        [Column(Order = 12)]
        [MaxLength(50)]
        public string ActionName { set; get; }
        [Column(Order = 13)]
        [MaxLength(50)]
        public string ControllerName { set; get; }
        [Column(Order = 14)]
        [MaxLength(50)]
        public string Optional { set; get; }
        [Column(Order = 15)]
        [MaxLength(50)]
        public string ModelName { set; get; }
        [Column(Order = 16)]
        [MaxLength(255)]
        public string Url { set; get; }
        [Column(Order = 17)]
        [MaxLength(50)]
        public string Icon { set; get; }
        [Column(Order = 18)]
        public PermissionMode Mode { set; get; }

        public virtual IList<RolePermission> RolePermissions { set; get; }
    }
}
