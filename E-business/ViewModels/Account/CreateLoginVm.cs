using Microsoft.AspNetCore.Mvc;

namespace E_business.ViewModels.Account
{
    public class CreateLoginVm
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
