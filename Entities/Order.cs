using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Requirements { get; set; }
        [Required]
        public int Cost { get; set; }
        [Required]
        public int DeliveryTime { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public int OrderStatusId { get; set; }
        public virtual Service Service { get; set; }
        public int ServiceId { get; set; }
        public virtual User Client { get; set; }
        public int ClientId { get; set; }
        public virtual User StaffTeam { get; set; }
        public int StaffTeamId { get; set; }
        public DateTime StartedOn { get; set; }
        public virtual Payment Payment { get; set; }
        public int PaymentId { get; set; }
        public virtual ICollection<Earnings> Earnings { get; set; }
        public virtual ICollection<Feedback> Feedback { get; set; }
        public virtual ICollection<OrderMessage> OrderChats { get; set; }
        public virtual ICollection<OrderFile> OrderFile { get; set; }


}
}