using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public virtual User Sender { get; set; }
        public int  SenderId { get; set; }
        public virtual User Receiver { get; set; }
        public int ReceiverId { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime SendOn { get; set; }
    }
}