namespace WebApi.Entities
{
    public class Earnings
    {
        public int Id { get; set; }
        public virtual EarningStatus EarningStatus { get; set; }
        public int EarningStatusId { get; set; }
        public int Amount { get; set; }
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }

    }
}