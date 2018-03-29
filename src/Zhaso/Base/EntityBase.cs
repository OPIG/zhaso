namespace Zhaso
{
    using Interfaces;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class EntityBase : IEntity
    {
        [Column(Order = 1)]
        public int Id { set; get; }
    }
}
