using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}