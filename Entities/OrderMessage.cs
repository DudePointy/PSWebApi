using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class OrderMessage
    {
        public int Id { get; set; }
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }

        public virtual User Sender { get; set; }
        public int SenderId { get; set; }

        [Required]
        public string Text { get; set; }
        public DateTime SentOn { get; set; }
    }
}