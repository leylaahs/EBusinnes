using E_business.Models.Base;

namespace E_business.Models
{
    public class Position:BaseEntity
    {
        public string Name { get; set; }
        public List<Employee>Employees { get; set; }
    }
}
