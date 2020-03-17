namespace WebApi.Entities
{
    public class UserSkill
    {
        public int Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int UserId { get; set; }
        public virtual Skill Skill { get; set; }
        public int SkillId { get; set; }
    }
}