using System;

namespace WebApi.Entities
{
    public class Payment
    {
        public int Id { get; set; } 
        public virtual PaymentStatus PaymentStatus { get; set; }
        public int PaymentStatusId { get; set; }
        public int Amount { get; set; }
        public DateTime PaidOn { get; set; }
        public string PaidVia { get; set; }

}
}