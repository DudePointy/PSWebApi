using System.Collections.Generic;

namespace WebApi.Entities
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public string ImagePath { get; set; }
        public virtual ICollection<Service> Services { get; set; }

}
}