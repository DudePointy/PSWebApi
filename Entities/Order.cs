﻿using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Requirements { get; set; }
        public int Cost { get; set; }
        public int DeliveryTime { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public int OrderStatusId { get; set; }
        public virtual Service Service { get; set; }
        public int ServiceId { get; set; }
        public virtual ApplicationUser Client { get; set; }
        public int ClientId { get; set; }
        public virtual ApplicationUser StaffTeam { get; set; }
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