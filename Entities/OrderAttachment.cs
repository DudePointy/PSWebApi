using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class OrderAttachment
    {
        public int Id { get; set; }
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }
        public virtual User Sender { get; set; }
        public int SenderId { get; set; }
        [Required]
        public string FilePath { get; set; }
        public virtual FileType FileType { get; set; }
        public int FileTypeId { get; set; }
        public DateTime SendOn { get; set; }
    }
}