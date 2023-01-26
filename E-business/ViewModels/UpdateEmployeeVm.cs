namespace E_business.ViewModels
{
    public class UpdateEmployeeVm
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public IFormFile? Image { get; set; }
        public double Salary { get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public string TwitterLink { get; set; }
        //public Position? Position { get; set; }
        public int PositionId { get; set; }
    }
}
