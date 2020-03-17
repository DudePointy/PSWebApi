using System.Collections.Generic;

namespace WebApi.Entities
{
    public class ContractStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}