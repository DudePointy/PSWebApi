using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Contract
    {
        public int Id { get; set; }
        public virtual Service Service { get; set; }
        public int ServiceId { get; set; }
        public virtual User Marketer { get; set; }
        public int MarketerId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public int MarketerCut { get; set; }
        public string CustomerOff { get; set; }
        public virtual  ContractStatus ContractStatus { get; set; }
        public int ContractStatusId { get; set; }
        [Required]
        public int NumberOfDays { get; set; }
        public DateTime StartOn { get; set; }
    }
}