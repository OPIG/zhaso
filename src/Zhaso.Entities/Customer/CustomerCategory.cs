namespace Zhaso.Entities
{
    public class CustomerCategory : RecordEntity
    {
        public string Category { set; get; }

        public int CustomerId { set; get; }
        public virtual Customer Customer { set; get; }
    }
}
