using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zhaso.Entities
{
    public class RolePermission : RecordEntity
    {
        [Column(Order = 11)]
        public int RoleId { set; get; }
        public virtual Role Role { set; get; }
        [Column(Order = 12)]
        public int PermissionId { set; get; }
        public virtual Permission Permission { set; get; }
    }
}
