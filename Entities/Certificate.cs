using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Certificate
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Institute { get; set; }
        [Required]
        public DateTime StartedOn { get; set; }
        [Required]
        public DateTime FinishedOn { get; set; }
        public string ImagePath { get; set; }
        public virtual User User { get; set; }
        //[Required]
        public int UserId { get; set; }
    }
}