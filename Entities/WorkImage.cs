using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class WorkImage
    {
        public int Id { get; set; }
        [Required]
        public string FilePath { get; set; }
        public virtual WorkDone WorkDone { get; set; }
        public int WorkDoneId { get; set; }

    }
}