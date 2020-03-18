using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class WorkDone
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int DeliveryDays { get; set; }
        [Required]
        public string ImagePath { get; set; }
        public virtual Service Service { get; set; }
        public int ServiceId { get; set; }
        public virtual ICollection<WorkImage> WorkImages { get; set; }


}
}