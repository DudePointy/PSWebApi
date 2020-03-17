using System.Collections.Generic;

namespace WebApi.Entities
{
    public class EarningStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Earnings> Earnings { get; set; }

}
}