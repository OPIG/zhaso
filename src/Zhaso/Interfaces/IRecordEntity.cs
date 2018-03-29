using System;

namespace Zhaso.Interfaces
{
    public interface IRecordEntity : IEntity, IOrder
    {
        DateTime CreateTime { get; set; }
        DateTime UpdateTime { get; set; }
        string CreateUser { get; set; }
        string UpdateUser { get; set; }
        bool Deleted { get; set; }
    }
}
