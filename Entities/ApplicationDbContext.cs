using Microsoft.EntityFrameworkCore;

namespace WebApi.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }


        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<AccountStatus> AccountStatuses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractStatus> ContractStatuses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Earnings> Earnings { get; set; }
        public DbSet<EarningStatus> EarningStatuses { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageAttachment> MessageAttachments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderAttachment> OrderAttachments { get; set; }
        public DbSet<OrderMessage> OrderMessages { get; set; }
        public DbSet<OrderFile> OrderFiles { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentStatus> PaymentStatuses { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceImage> ServiceImages { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<StaffTeam> StaffTeams { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<WorkDone> WorkDone { get; set; }
        public DbSet<WorkImage> WorkImages { get; set; }
    }
}