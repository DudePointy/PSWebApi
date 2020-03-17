using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Cost { get; set; }
        public int DeliveryDays { get; set; }
        public int RankPoints { get; set; }
        public string Description { get; set; }
        public string PrimaryImg { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public int SubCategoryId { get; set; }
        public DateTime StartedOn { get; set; }
        public virtual ApplicationUser Solutioner { get; set; }
        public int SolutionerId { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ServiceImage> ServiceImages { get; set; }
        public virtual ICollection<WorkDone> WorkDone { get; set; }

}
}