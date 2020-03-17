using System;

namespace WebApi.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public virtual ApplicationUser Sender { get; set; }
        public int  SenderId { get; set; }
        public virtual ApplicationUser Receiver { get; set; }
        public int ReceiverId { get; set; }
        public string Text { get; set; }
        public DateTime SendOn { get; set; }
    }
}