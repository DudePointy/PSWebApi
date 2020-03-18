using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Entities
{
    public class PointyHandler
    {
        private readonly ApplicationDbContext db;

        public PointyHandler(ApplicationDbContext context)
        {
            db = context;
        }

        #region AccountStatus

        public void AddAccountStatus(AccountStatus accountStatus)
        {
            db.AccountStatuses.Add(accountStatus);
            db.SaveChanges();
        }

        public void DeleteAccountStatus(int id)
        {
            var accountStatus = db.AccountStatuses.FirstOrDefault(c => c.Id == id);
            if (accountStatus != null)
            {
                db.AccountStatuses.Remove(accountStatus);
                db.SaveChanges();
            }

        }

        public ICollection<AccountStatus> GetAllAccountStatuses()
        {
            return db.AccountStatuses.ToList();
        }

        public AccountStatus AccountStatusDetails(int id)
        {
            return db.AccountStatuses.FirstOrDefault(c => c.Id == id);

        }

        public void EditAccountStatus(AccountStatus accountStatus)
        {
            var accountStatusInDb = db.AccountStatuses.FirstOrDefault(c => c.Id == accountStatus.Id);
            if (accountStatusInDb != null)
            {
                accountStatusInDb.Name = accountStatus.Name;
                db.SaveChanges();
            }
        }

        #endregion

        #region Category

        public void AddCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }


        public void DeleteCategory(int id)
        {
            var categoryInDb = db.Categories.FirstOrDefault(c => c.Id == id);
            if (categoryInDb != null)
            {
                db.Categories.Remove(categoryInDb);
                db.SaveChanges();
            }
        }

        public ICollection<Category> GetAllCategories()
        {
            return db.Categories.ToList();
        }

        public Category CategoryDetails(int id)
        {
            return db.Categories.FirstOrDefault(c => c.Id == id);
        }

        public void EditCategory(Category category)
        {
            var categoryInDb = db.Categories.FirstOrDefault(c => c.Id == category.Id);
            if (categoryInDb != null)
            {
                categoryInDb.Name = category.Name;
                db.SaveChanges();
            }
        }

        #endregion

        #region Certificate

        public void AddCertificate(Certificate certificate)
        {
            db.Certificates.Add(certificate);
            db.SaveChanges();
        }

        public void DeleteCertificate(int id)
        {
            var certificate = db.Certificates.FirstOrDefault(c => c.Id == id);
            if (certificate != null)
            {
                db.Certificates.Remove(certificate);
                db.SaveChanges();
            }

        }

        public ICollection<Certificate> GetAllCertificates()
        {
            return db.Certificates.Include(c => c.User).ToList();
        }

        public Certificate CertificateDetails(int id)
        {
            return db.Certificates.Include(c => c.User).FirstOrDefault(c => c.Id == id);
        }

        public ICollection<Certificate> GetUserCertificates(int id)
        {
            return db.Certificates.Include(c => c.User).Where(c => c.UserId == id).ToList();
        }

        public void EditCertificate(Certificate certificate)
        {
            var certificateInDb = db.Certificates.FirstOrDefault(c => c.Id == certificate.Id);
            if (certificateInDb != null)
            {
                certificateInDb.Title = certificate.Title;
                certificateInDb.Institute = certificate.Institute;
                certificateInDb.StartedOn = certificate.StartedOn;
                certificateInDb.FinishedOn = certificate.FinishedOn;
                certificateInDb.ImagePath = certificate.ImagePath;
                db.SaveChanges();
            }
        }

        #endregion

        #region Contracts

        public void AddContract(Contract contract)
        {
            db.Contracts.Add(contract);
            db.SaveChanges();
        }

        public void DeleteContract(int id)
        {
            var contract = db.Contracts.FirstOrDefault(c => c.Id == id);
            if (contract != null)
            {
                db.Contracts.Remove(contract);
                db.SaveChanges();
            }
        }

        public ICollection<Contract> GetAllContracts()
        {
            return db.Contracts
                .Include(c => c.ContractStatus)
                .Include(c => c.Marketer)
                .Include(c => c.Service)
                .ToList();
        }

        public Contract ContractDetails(int id)
        {
            return db.Contracts
                .Include(c => c.ContractStatus)
                .Include(c => c.Marketer)
                .Include(c => c.Service)
                .FirstOrDefault(c => c.Id == id);
        }

        public ICollection<Contract> GetUserContracts(int id)
        {
            return db.Contracts
                .Include(c => c.ContractStatus)
                .Include(c => c.Marketer)
                .Include(c => c.Service).Where(c => c.MarketerId == id).ToList();
        }

        public void EditContract(Contract contract)
        {
            var contractInDb = db.Contracts.FirstOrDefault(c => c.Id == contract.Id);
            if (contractInDb != null)
            {
                contractInDb.ServiceId = contract.ServiceId;
                contractInDb.MarketerId = contract.MarketerId;
                contractInDb.Title = contract.Title;
                contractInDb.Details = contract.Details;
                contractInDb.MarketerCut = contract.MarketerCut;
                contractInDb.CustomerOff = contract.CustomerOff;
                contractInDb.ContractStatusId = contract.ContractStatusId;
                contractInDb.NumberOfDays = contract.NumberOfDays;
                contractInDb.StartOn = contract.StartOn;
                db.SaveChanges();
            }
        }

        #endregion

        #region ContractStatus

        public void AddContractStatus(ContractStatus contractStatus)
        {
            db.ContractStatuses.Add(contractStatus);
            db.SaveChanges();
        }

        public void DeleteContractStatus(int id)
        {
            var contractStatus = db.ContractStatuses.FirstOrDefault(c => c.Id == id);
            if (contractStatus != null)
            {
                db.ContractStatuses.Remove(contractStatus);
                db.SaveChanges();
            }

        }

        public ICollection<ContractStatus> GetAllContractStatuses()
        {
            return db.ContractStatuses.ToList();
        }

        public ContractStatus ContractStatusDetails(int id)
        {
            return db.ContractStatuses.FirstOrDefault(c => c.Id == id);

        }

        public void EditContractStatus(ContractStatus contractStatus)
        {
            var contractStatusInDb = db.ContractStatuses.FirstOrDefault(c => c.Id == contractStatus.Id);
            if (contractStatusInDb != null)
            {
                contractStatusInDb.Name = contractStatus.Name;
                db.SaveChanges();
            }
        }

        #endregion

        #region Earnings

        public void AddEarnings(Earnings earnings)
        {
            db.Earnings.Add(earnings);
            db.SaveChanges();
        }

        public void DeleteEarnings(int id)
        {
            var earnings = db.Earnings.FirstOrDefault(e => e.Id == id);
            if (earnings != null)
            {
                db.Earnings.Remove(earnings);
                db.SaveChanges();
            }
        }

        public ICollection<Earnings> GetAllEarnings()
        {
            return db.Earnings.Include(e => e.EarningStatus).Include(e => e.Order).ToList();
        }

        public Earnings EarningDetails(int id)
        {
            return db.Earnings.Include(e => e.EarningStatus).Include(e => e.Order).FirstOrDefault(e => e.Id == id);
        }

        public void EditEarnings(Earnings earnings)
        {
            var earningsInDb = db.Earnings.FirstOrDefault(e => e.Id == earnings.Id);
            if (earningsInDb != null)
            {
                earningsInDb.EarningStatusId = earnings.EarningStatusId;
                earningsInDb.Amount = earnings.Amount;
                earningsInDb.OrderId = earnings.OrderId;
                db.SaveChanges();
            }

        }

        #endregion

        #region EarningStatus

        public void AddEarningStatus(EarningStatus earningStatus)
        {
            db.EarningStatuses.Add(earningStatus);
            db.SaveChanges();
        }

        public void DeleteEarningStatus(int id)
        {
            var earningStatus = db.EarningStatuses.FirstOrDefault(e => e.Id == id);
            if (earningStatus != null)
            {
                db.EarningStatuses.Remove(earningStatus);
                db.SaveChanges();
            }
        }

        public ICollection<EarningStatus> GetAllEarningStatus()
        {
            return db.EarningStatuses.ToList();
        }

        public EarningStatus EarningStatusDetails(int id)
        {
            return db.EarningStatuses.FirstOrDefault(e => e.Id == id);
        }

        public void EditEarningStatus(EarningStatus earningStatus)
        {
            var earningStatusInDb = db.EarningStatuses.FirstOrDefault(e => e.Id == earningStatus.Id);
            if (earningStatusInDb != null)
            {
                earningStatusInDb.Name = earningStatus.Name;
                db.SaveChanges();
            }

        }

        #endregion

        #region Feedback

        public void AddFeedback(Feedback feedback)
        {
            db.Feedback.Add(feedback);
            db.SaveChanges();
        }

        public void DeleteFeedback(int id)
        {
            var feedback = db.Feedback.FirstOrDefault(f => f.Id == id);
            if (feedback != null)
            {
                db.Feedback.Remove(feedback);
                db.SaveChanges();
            }
        }

        public ICollection<Feedback> GetAllFeedback()
        {
            return db.Feedback.Include(f => f.Order).ToList();
        }

        public Feedback FeedbackDetails(int id)
        {
            return db.Feedback.Include(f => f.Order).FirstOrDefault(f => f.Id == id);
        }

        public void EditFeedback(Feedback feedback)
        {
            var feedbackInDb = db.Feedback.Include(f => f.Order).FirstOrDefault(f => f.Id == feedback.Id);
            if (feedbackInDb != null)
            {
                feedbackInDb.Comment = feedback.Comment;
                feedbackInDb.OrderId = feedback.OrderId;
                feedbackInDb.Stars = feedback.Stars;
                db.SaveChanges();
            }
        }

        #endregion

        #region Order

        public void AddOrder(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var order = db.Orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                db.Orders.Remove(order);
                db.SaveChanges();
            }
        }

        public ICollection<Order> GetAllOrders()
        {
            return db.Orders
                .Include(o => o.OrderStatus)
                .Include(o => o.Service)
                .Include(o => o.Client)
                .Include(o => o.StaffTeam)
                .Include(o => o.Payment)
                .ToList();
        }

        public Order OrderDetails(int id)
        {
            return db.Orders
                .Include(o => o.OrderStatus)
                .Include(o => o.Service)
                .Include(o => o.Client)
                .Include(o => o.StaffTeam)
                .Include(o => o.Payment)
                .FirstOrDefault(o => o.Id == id);
        }

        public ICollection<Order> GetClientOrders(int id)
        {
            return db.Orders
                .Include(o => o.OrderStatus)
                .Include(o => o.Service)
                .Include(o => o.Client)
                .Include(o => o.StaffTeam)
                .Include(o => o.Payment)
                .Where(o => o.ClientId == id).ToList();
        }


        public ICollection<Order> GetStaffTeamOrders(int id)
        {
            return db.Orders
                .Include(o => o.OrderStatus)
                .Include(o => o.Service)
                .Include(o => o.Client)
                .Include(o => o.StaffTeam)
                .Include(o => o.Payment)
                .Where(o => o.StaffTeamId == id).ToList();
        }

        public void EditOrder(Order order)
        {
            var orderInDb = db.Orders.FirstOrDefault(o => o.Id == order.Id);
            if (orderInDb != null)
            {
                orderInDb.Title = order.Title;
                orderInDb.Requirements = order.Requirements;
                orderInDb.Cost = order.Cost;
                orderInDb.DeliveryTime = order.DeliveryTime;
                orderInDb.OrderStatusId = order.OrderStatusId;
                orderInDb.ServiceId = order.ServiceId;
                orderInDb.ClientId = order.ClientId;
                orderInDb.StaffTeamId = order.StaffTeamId;
                orderInDb.StartedOn = order.StartedOn;
                orderInDb.PaymentId = order.PaymentId;
                db.SaveChanges();
            }
        }
        #endregion

        #region OrderStatus

        public void AddOrderStatus(OrderStatus orderStatus)
        {
            db.OrderStatuses.Add(orderStatus);
            db.SaveChanges();
        }

        public void DeleteOrderStatus(int id)
        {
            var orderStatus = db.OrderStatuses.FirstOrDefault(o => o.Id == id);
            if (orderStatus != null)
            {
                db.OrderStatuses.Remove(orderStatus);
                db.SaveChanges();
            }
        }

        public ICollection<OrderStatus> GetAllOrderStatuses()
        {
            return db.OrderStatuses.ToList();
        }

        public OrderStatus OrderStatusDetails(int id)
        {
            return db.OrderStatuses.FirstOrDefault(o => o.Id == id);
        }

        public void EditOrderStatus(OrderStatus orderStatus)
        {
            var orderStatusInDb = db.OrderStatuses.FirstOrDefault(o => o.Id == orderStatus.Id);
            if (orderStatusInDb != null)
            {
                orderStatusInDb.Name = orderStatus.Name;
                db.SaveChanges();
            }
        }

        #endregion

        #region Payment

        public void AddPayment(Payment payment)
        {
            db.Payments.Add(payment);
            db.SaveChanges();
        }

        public void DeletePayment(int id)
        {
            var payment = db.Payments.FirstOrDefault(p => p.Id == id);
            if (payment != null)
            {
                db.Payments.Remove(payment);
                db.SaveChanges();
            }
        }

        public ICollection<Payment> GetAllPayments()
        {
            return db.Payments.Include(p => p.PaymentStatus).ToList();
        }

        public Payment PaymentDetails(int id)
        {
            return db.Payments.Include(p => p.PaymentStatus).FirstOrDefault(p => p.Id == id);
        }

        public void EditPayment(Payment payment)
        {
            var paymentInDb = db.Payments.FirstOrDefault(p => p.Id == payment.Id);
            if (paymentInDb != null)
            {
                paymentInDb.PaymentStatusId = payment.PaymentStatusId;
                paymentInDb.Amount = payment.Amount;
                paymentInDb.PaidOn = payment.PaidOn;
                paymentInDb.PaidVia = payment.PaidVia;
                db.SaveChanges();
            }
        }

        #endregion

        #region PaymentStatus

        public void AddPaymentStatus(PaymentStatus paymentStatus)
        {
            db.PaymentStatuses.Add(paymentStatus);
            db.SaveChanges();
        }

        public void DeletePaymentStatus(int id)
        {
            var paymentStatus = db.PaymentStatuses.FirstOrDefault(p => p.Id == id);
            if (paymentStatus != null)
            {
                db.PaymentStatuses.Remove(paymentStatus);
                db.SaveChanges();
            }
        }

        public ICollection<PaymentStatus> GetAllPaymentStatuses()
        {
            return db.PaymentStatuses.ToList();
        }

        public PaymentStatus PaymentStatusDetails(int id)
        {
            return db.PaymentStatuses.FirstOrDefault(p => p.Id == id);
        }

        public void EditPaymentStatus(PaymentStatus paymentStatus)
        {
            var paymentStatusInDb = db.PaymentStatuses.FirstOrDefault(p => p.Id == paymentStatus.Id);
            if (paymentStatusInDb != null)
            {
                paymentStatusInDb.Name = paymentStatus.Name;
                db.SaveChanges();
            }
        }

        #endregion

        #region Service

        public void AddService(Service service)
        {
            db.Services.Add(service);
            db.SaveChanges();
        }

        public void DeleteService(int id)
        {
            var service = db.Services.FirstOrDefault(s => s.Id == id);
            if (service != null)
            {
                db.Services.Remove(service);
                db.SaveChanges();
            }
        }

        public ICollection<Service> GetAllServices()
        {
            return db.Services.Include(s => s.SubCategory).Include(s => s.Solutioner).ToList();
        }

        public Service ServiceDetails(int id)
        {
            return db.Services.Include(s => s.SubCategory).Include(s => s.Solutioner).FirstOrDefault(s => s.Id == id);
        }

        public ICollection<Service> GetUserServices(int id)
        {
            return db.Services.Include(s => s.SubCategory).Include(s => s.Solutioner).Where(s => s.SolutionerId == id).ToList();
        }

        public void EditService(Service service)
        {
            var serviceInDb = db.Services.FirstOrDefault(s => s.Id == service.Id);
            if (serviceInDb != null)
            {
                serviceInDb.Title = service.Title;
                serviceInDb.Cost = service.Cost;
                serviceInDb.DeliveryDays = service.DeliveryDays;
                serviceInDb.RankPoints = service.RankPoints;
                serviceInDb.Description = service.Description;
                serviceInDb.PrimaryImg = service.PrimaryImg;
                serviceInDb.SubCategoryId = service.SubCategoryId;
                serviceInDb.StartedOn = service.StartedOn;
                serviceInDb.SolutionerId = service.SolutionerId;
                db.SaveChanges();
            }
        }

        #endregion

        #region ServiceImage

        public void AddServiceImage(ServiceImage service)
        {
            db.ServiceImages.Add(service);
            db.SaveChanges();
        }

        public void DeleteServiceImage(int id)
        {
            var service = db.ServiceImages.FirstOrDefault(s => s.Id == id);
            if (service != null)
            {
                db.ServiceImages.Remove(service);
                db.SaveChanges();
            }
        }

        public ICollection<ServiceImage> GetAllServicesImages()
        {
            return db.ServiceImages.Include(s => s.Service).ToList();
        }

        public ServiceImage ServiceImageDetails(int id)
        {
            return db.ServiceImages.Include(s => s.Service).FirstOrDefault(s => s.Id == id);
        }

        public void EditServiceImage(ServiceImage service)
        {
            var serviceInDb = db.ServiceImages.FirstOrDefault(s => s.Id == service.Id);
            if (serviceInDb != null)
            {
                serviceInDb.FilePath = service.FilePath;
                serviceInDb.ServiceId = service.ServiceId;
                db.SaveChanges();
            }
        }

        #endregion

        #region Skill

        public void AddSkill(Skill skill)
        {
            db.Skills.Add(skill);
            db.SaveChanges();
        }

        public void DeleteSkill(int id)
        {
            var skill = db.Skills.FirstOrDefault(s => s.Id == id);
            if (skill != null)
            {
                db.Skills.Remove(skill);
                db.SaveChanges();
            }
        }

        public ICollection<Skill> GetAllSkills()
        {
            return db.Skills.ToList();
        }

        public Skill SkillDetails(int id)
        {
            return db.Skills.FirstOrDefault(s => s.Id == id);
        }

        public void EditSkill(Skill skill)
        {
            var skillInDb = db.Skills.FirstOrDefault(s => s.Id == skill.Id);
            if (skillInDb != null)
            {
                skillInDb.Name = skill.Name;
                db.SaveChanges();
            }
        }

        #endregion

        #region StaffTeam

        public void AddStaffTeam(StaffTeam staffTeam)
        {
            db.StaffTeams.Add(staffTeam);
            db.SaveChanges();
        }

        public void DeleteStaffTeam(int id)
        {
            var staffTeam = db.StaffTeams.FirstOrDefault(s => s.Id == id);
            if (staffTeam != null)
            {
                db.StaffTeams.Remove(staffTeam);
                db.SaveChanges();
            }
        }

        public ICollection<StaffTeam> GetAllStaffTeams()
        {
            return db.StaffTeams.Include(s => s.User).ToList();
        }

        public StaffTeam StaffTeamDetails(int id)
        {
            return db.StaffTeams.Include(s => s.User).FirstOrDefault(s => s.Id == id);
        }

        public ICollection<StaffTeam> GetUserStaffTeams(int id)
        {
            return db.StaffTeams.Include(s => s.User).Where(s => s.UserId == id).ToList();
        }

        public void EditStaffTeam(StaffTeam staffTeam)
        {
            var staffTeamInDb = db.StaffTeams.FirstOrDefault(s => s.Id == staffTeam.Id);
            if (staffTeamInDb != null)
            {
                staffTeamInDb.TeamCode = staffTeam.TeamCode;
                staffTeamInDb.UserId = staffTeam.UserId;
                db.SaveChanges();
            }
        }

        #endregion

        #region SubCategory

        public void AddSubCategory(SubCategory subCategory)
        {
            db.SubCategories.Add(subCategory);
            db.SaveChanges();
        }

        public void DeleteSubCategory(int id)
        {
            var subcategory = db.SubCategories.FirstOrDefault(s => s.Id == id);
            if (subcategory != null)
            {
                db.SubCategories.Remove(subcategory);
                db.SaveChanges();
            }
        }

        public ICollection<SubCategory> GetAllSubCategories()
        {
            return db.SubCategories.Include(s => s.Category).ToList();
        }

        public SubCategory SubCategoryDetails(int id)
        {
            return db.SubCategories.Include(s => s.Category).FirstOrDefault(s => s.Id == id);
        }

        public void EditSubCategory(SubCategory subCategory)
        {
            var subCategoryInDb = db.SubCategories.FirstOrDefault(s => s.Id == subCategory.Id);
            if (subCategoryInDb != null)
            {
                subCategoryInDb.Name = subCategory.Name;
                subCategoryInDb.ImagePath = subCategory.ImagePath;
                subCategoryInDb.CategoryId = subCategory.CategoryId;
                db.SaveChanges();
            }
        }

        #endregion

        #region WorkDone

        public void AddWorkDone(WorkDone workDone)
        {
            db.WorkDone.Add(workDone);
            db.SaveChanges();
        }

        public void DeleteWorkDone(int id)
        {
            var workDone = db.WorkDone.FirstOrDefault(w => w.Id == id);
            if (workDone != null)
            {
                db.WorkDone.Remove(workDone);
                db.SaveChanges();
            }
        }

        public ICollection<WorkDone> GetAllWorkDone()
        {
            return db.WorkDone.Include(w => w.Service).ToList();
        }

        public WorkDone WorkDoneDetails(int id)
        {
            return db.WorkDone.Include(w => w.Service).FirstOrDefault(w => w.Id == id);
        }

        public void EditWorkDone(WorkDone workDone)
        {
            var workDoneInDb = db.WorkDone.FirstOrDefault(w => w.Id == workDone.Id);
            if (workDoneInDb != null)
            {
                workDoneInDb.Title = workDone.Title;
                workDoneInDb.Description = workDone.Description;
                workDoneInDb.DeliveryDays = workDone.DeliveryDays;
                workDoneInDb.ImagePath = workDone.ImagePath;
                workDoneInDb.ServiceId = workDone.ServiceId;
                db.SaveChanges();
            }
        }

        #endregion

        #region Messages

        public void AddMessage(Message message)
        {
            db.Messages.Add(message);
            db.SaveChanges();
        }

        public void DeleteMessage(int id)
        {
            var message = db.Messages.FirstOrDefault(e => e.Id == id);
            if (message != null)
            {
                db.Messages.Remove(message);
                db.SaveChanges();
            }
        }

        public ICollection<Message> GetAllMessages()
        {
            return db.Messages.Include(m => m.Sender).Include(m => m.Receiver).ToList();
        }

        public Message MessageDetails(int id)
        {
            return db.Messages.Include(m => m.Sender).Include(m => m.Receiver).FirstOrDefault(e => e.Id == id);
        }

        public void EditMessage(Message message)
        {
            var messagesInDb = db.Messages.FirstOrDefault(e => e.Id == message.Id);
            if (messagesInDb != null)
            {
                messagesInDb.SenderId = message.SenderId;
                messagesInDb.ReceiverId = message.ReceiverId;
                messagesInDb.SendOn = message.SendOn;
                messagesInDb.Text = message.Text;
                db.SaveChanges();
            }

        }

        #endregion

        #region MessageAttachment


        public void AddMessageAttachment(MessageAttachment messageAttachment)
        {
            db.MessageAttachments.Add(messageAttachment);
            db.SaveChanges();
        }

        public void DeleteMessageAttachment(int id)
        {
            var message = db.MessageAttachments.FirstOrDefault(m => m.Id == id);
            if (message != null)
            {
                db.MessageAttachments.Remove(message);
                db.SaveChanges();
            }
        }

        public ICollection<MessageAttachment> GetAllMessageAttachments()
        {
            return db.MessageAttachments.Include(m => m.Sender).Include(m => m.Receiver).Include(m => m.FileType).ToList();
        }

        public MessageAttachment MessageAttachmentDetails(int id)
        {
            return db.MessageAttachments.Include(m => m.Sender).Include(m => m.Receiver).Include(m => m.FileType).FirstOrDefault(m => m.Id == id);
        }

        public void EditMessageAttachment(MessageAttachment attachment)
        {
            var messageAttachmentInDb = db.MessageAttachments.FirstOrDefault(m => m.Id == attachment.Id);
            if (messageAttachmentInDb != null)
            {
                messageAttachmentInDb.SenderId = attachment.SenderId;
                messageAttachmentInDb.ReceiverId = attachment.ReceiverId;
                messageAttachmentInDb.FilePath = attachment.FilePath;
                messageAttachmentInDb.FileTypeId = attachment.FileTypeId;
                messageAttachmentInDb.SendOn = attachment.SendOn;
                db.SaveChanges();
            }
        }
        #endregion

        #region OrderAttachment

        public void AddOrderAttachment(OrderAttachment attachment)
        {
            db.OrderAttachments.Add(attachment);
            db.SaveChanges();
        }

        public void DeleteOrderAttachment(int id)
        {
            var orderAttachment = db.OrderAttachments.FirstOrDefault(o => o.Id == id);
            if (orderAttachment != null)
            {
                db.OrderAttachments.Remove(orderAttachment);
                db.SaveChanges();
            }
        }

        public ICollection<OrderAttachment> GetAllOrderAttachment()
        {
            return db.OrderAttachments.Include(o => o.FileType).Include(o => o.Sender).Include(o => o.Order).ToList();
        }

        public OrderAttachment OrderAttachmentDetails(int id)
        {
            return db.OrderAttachments.Include(o => o.FileType).Include(o => o.Sender).Include(o => o.Order)
                .FirstOrDefault(o => o.Id == id);
        }

        public void EditOrderAttachment(OrderAttachment attachment)
        {
            var orderAttachmentInDb = db.OrderAttachments.FirstOrDefault(o => o.Id == attachment.Id);
            if (orderAttachmentInDb != null)
            {
                orderAttachmentInDb.OrderId = attachment.OrderId;
                orderAttachmentInDb.SenderId = attachment.SenderId;
                orderAttachmentInDb.FileTypeId = attachment.FileTypeId;
                orderAttachmentInDb.SendOn = attachment.SendOn;
                orderAttachmentInDb.FilePath = attachment.FilePath;
                db.SaveChanges();
            }
        }

        #endregion

        #region WorkImages

        public void AddWorkImage(WorkImage workImage)
        {
            db.WorkImages.Add(workImage);
            db.SaveChanges();
        }

        public void DeleteWorkImages(int id)
        {
            var workImages = db.WorkImages.FirstOrDefault(w => w.Id == id);
            if (workImages != null)
            {
                db.WorkImages.Remove(workImages);
                db.SaveChanges();
            }
        }

        public ICollection<WorkImage> GetAllWorkImages()
        {
            return db.WorkImages.Include(w => w.WorkDone).ToList();
        }

        public WorkImage WorkImageDetails(int id)
        {
            return db.WorkImages.Include(w => w.WorkDone).FirstOrDefault(w => w.Id == id);
        }

        public void EditWorkImage(WorkImage workImage)
        {
            var WorkImageInDb = db.WorkImages.FirstOrDefault(w => w.Id == workImage.Id);
            if (WorkImageInDb != null)
            {
                WorkImageInDb.FilePath = workImage.FilePath;
                WorkImageInDb.WorkDoneId = workImage.WorkDoneId;
                db.SaveChanges();
            }
        }

        #endregion

        #region OrderFile


        public void AddOrderFile(OrderFile orderFile)
        {
            db.OrderFiles.Add(orderFile);
            db.SaveChanges();
        }

        public void DeleteOrderFile(int id)
        {
            var orderFile = db.OrderFiles.FirstOrDefault(o => o.Id == id);
            if (orderFile != null)
            {
                db.OrderFiles.Remove(orderFile);
                db.SaveChanges();
            }
        }

        public ICollection<OrderFile> GetAllOrderFiles()
        {
            return db.OrderFiles.Include(o => o.FileType).Include(o => o.Order).ToList();
        }

        public OrderFile OrderFileDetails(int id)
        {
            return db.OrderFiles.Include(o => o.FileType).Include(o => o.Order).FirstOrDefault(o => o.Id == id);
        }

        public void EditOrderFile(OrderFile orderFile)
        {
            var orderFileInDb = db.OrderFiles.FirstOrDefault(o => o.Id == orderFile.Id);
            if (orderFileInDb != null)
            {
                orderFileInDb.FilePath = orderFile.FilePath;
                orderFileInDb.OrderId = orderFile.OrderId;
                orderFileInDb.FileTypeId = orderFile.FileTypeId;
                orderFileInDb.Time = orderFile.Time;
                db.SaveChanges();
            }
        }

        #endregion

        #region OrderMessage


        public void AddOrderMessage(OrderMessage orderMessage)
        {
            db.OrderMessages.Add(orderMessage);
            db.SaveChanges();
        }

        public void DeleteOrderMessage(int id)
        {
            var orderMessage = db.OrderMessages.FirstOrDefault(o => o.Id == id);
        }

        public ICollection<OrderMessage> GetAllOrderMessages()
        {
            return db.OrderMessages.Include(o => o.Sender).Include(o => o.Order).ToList();
        }

        public OrderMessage OrderMessageDetails(int id)
        {
            return db.OrderMessages.Include(o => o.Sender).Include(o => o.Order).FirstOrDefault(o => o.Id == id);
        }

        public void EditOrderMessage(OrderMessage orderMessage)
        {
            var orderMessageInDb = db.OrderMessages.FirstOrDefault(o => o.Id == orderMessage.Id);
            if (orderMessageInDb != null)
            {
                orderMessageInDb.OrderId = orderMessage.OrderId;
                orderMessageInDb.SenderId = orderMessage.SenderId;
                orderMessageInDb.Text = orderMessage.Text;
                orderMessageInDb.SentOn = orderMessage.SentOn;
                db.SaveChanges();
            }

        }

        #endregion

        #region UserSkill


        public void AddUserSkill(UserSkill skill)
        {
            db.UserSkills.Add(skill);
            db.SaveChanges();
        }

        public void DeleteUserSkill(int id)
        {
            var skill = db.UserSkills.FirstOrDefault(s => s.Id == id);
            if (skill != null)
            {
                db.UserSkills.Remove(skill);
                db.SaveChanges();
            }
        }

        public ICollection<UserSkill> GetAllUserSkills()
        {
            return db.UserSkills.ToList();
        }
        public ICollection<UserSkill> GetAllUserSkills(int id)
        {
            return db.UserSkills.Where(u => u.UserId == id).ToList();
        }

        public UserSkill UserSkillDetails(int id)
        {
            return db.UserSkills.FirstOrDefault(u => u.Id == id);
        }

        public void EditUserSkill(UserSkill skill)
        {
            var skillInDb = db.UserSkills.FirstOrDefault(u => u.Id == skill.Id);
            if (skillInDb != null)
            {
                skillInDb.UserId = skill.UserId;
                skillInDb.SkillId = skill.SkillId;
                db.SaveChanges();
            }
        }




        #endregion

        #region User


        public void AddUser(User user)
        {
            db.ApplicationUsers.Add(user);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                db.ApplicationUsers.Remove(user);
                db.SaveChanges();
            }
        }

        public ICollection<User> GetAllUsers()
        {
            return db.ApplicationUsers.ToList();
        }

        public User UserDetails(int id)
        {
            return db.ApplicationUsers
                .Include(u => u.Certificates)
                .Include(u => u.Contracts)
                .Include(u => u.Services)
                .Include(u => u.OrderChats)
                .Include(u => u.StaffTeams)
                .Include(u => u.UserSkills)
                .FirstOrDefault(u => u.Id == id);
        }

        public void EditUser(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }

        #endregion

    }
}