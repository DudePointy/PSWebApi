using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Payment
    {
        public int Id { get; set; } 
        public virtual PaymentStatus PaymentStatus { get; set; }
        public int PaymentStatusId { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public DateTime PaidOn { get; set; }
        [Required]
        public string PaidVia { get; set; }

}
}