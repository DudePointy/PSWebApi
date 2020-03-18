using System.Collections.Generic;

namespace WebApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<OrderMessage> OrderChats { get; set; }
        public virtual ICollection<StaffTeam> StaffTeams { get; set; }
        public virtual ICollection<UserSkill> UserSkills { get; set; }
    }
}