namespace WebApi.Entities
{
    public class StaffTeam
    {
        public int Id { get; set; }
        public string TeamCode { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
    }
}