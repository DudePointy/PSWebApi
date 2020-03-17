using System;

namespace WebApi.Entities
{
    public class OrderFile
    {
        public int Id { get; set; }
        public virtual FileType FileType{ get; set; }
        public int FileTypeId { get; set; }
        public string FilePath { get; set; }  
        public DateTime Time { get; set; }  
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }

    }
}