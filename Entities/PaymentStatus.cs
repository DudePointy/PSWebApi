using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class PaymentStatus
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}