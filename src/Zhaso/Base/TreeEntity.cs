using System.Collections.Generic;

namespace Zhaso
{
    using Interfaces;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class TreeEntity<T> : RecordEntity, ITreeEntity<T> where T : TreeEntity<T>
    {
        [Column(Order = 2)]
        public int? ParentId { get; set; }
        [Column(Order = 3)]
        public string Path { get; set; }
        public T Parent { get; set; }
        public ICollection<T> Children { get; set; } = new List<T>();
    }
}
