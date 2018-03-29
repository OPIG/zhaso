using System.Collections.Generic;

namespace Zhaso.Interfaces
{
    public interface ITreeEntity<T> where T : IRecordEntity
    {
        int? ParentId { get; set; }
        string Path { get; set; }
        T Parent { get; set; }
        ICollection<T> Children { get; set; }
    }
}
