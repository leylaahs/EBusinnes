using E_business.Models;

namespace E_business.ViewModels
{
    public class CreatePositionVm
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
