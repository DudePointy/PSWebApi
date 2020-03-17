using System.Collections.Generic;

namespace WebApi.Entities
{
    public class FileType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<OrderFile> OrderFiles { get; set; }

}
}