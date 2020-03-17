using System.Collections.Generic;

namespace WebApi.Entities
{
    public class WorkDone
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DeliveryDays { get; set; }
        public string ImagePath { get; set; }
        public virtual Service Service { get; set; }
        public int ServiceId { get; set; }
        public virtual ICollection<WorkImage> WorkImages { get; set; }


}
}