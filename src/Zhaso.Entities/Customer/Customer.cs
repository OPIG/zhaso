using System.Collections.Generic;

namespace Zhaso.Entities
{
    public class Customer : RecordEntity
    {
        public string Name { set; get; }
        public string ShortName { set; get; }
        public string EnglishName { set; get; }
        public string Telphone { set; get; }
        public string Prince { set; get; }
        public string City { set; get; }
        public string Address { set; get; }
        public string Email { set; get; }
        public string LegalPerson { set; get; }
        public string Category { set; get; }

        public virtual IList<CustomerCategory> CustomerCategories { set; get; }
    }
}
