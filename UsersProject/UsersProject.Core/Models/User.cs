
namespace UsersProject.Core.Models
{
    public class User
    {
        public string Password { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string ZipIndex { get; set; }

        public bool IsEmailConfirmed { get; set; }
    }
}
