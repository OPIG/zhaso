using System.ComponentModel.DataAnnotations.Schema;

namespace Zhaso.Entities
{
    public class RoleUser : RecordEntity
    {
        [Column(Order = 11)]
        public int RoleId { set; get; }
        public virtual Role Role { set; get; }
        [Column(Order = 12)]
        public int UserId { set; get; }
        public virtual User User { set; get; }
    }
}
