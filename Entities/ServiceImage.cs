namespace WebApi.Entities
{
    public class ServiceImage
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public virtual Service Service{ get; set; }
        public int ServiceId { get; set; }
    }
}