using System;

namespace WebApi.Entities
{
    public class Certificate
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Institute { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime FinishedOn { get; set; }
        public string ImagePath { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
    }
}