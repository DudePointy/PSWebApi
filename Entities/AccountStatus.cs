using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class AccountStatus
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}