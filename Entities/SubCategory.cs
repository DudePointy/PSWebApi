using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class SubCategory
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public string ImagePath { get; set; }
        public virtual ICollection<Service> Services { get; set; }

}
}