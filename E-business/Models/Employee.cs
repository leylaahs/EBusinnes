using E_business.Models.Base;

namespace E_business.Models
{
    public class Employee:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public double Salary { get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public string TwitterLink { get; set; }
        public Position Position { get; set; }
        public int PositionId { get; set; }
    }
}
