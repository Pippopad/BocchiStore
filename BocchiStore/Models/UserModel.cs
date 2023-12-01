namespace BocchiStore.Models
{
    public struct Top3User
    {
        public int UserId { get; set; }
        public int BookCount { get; set; }

        public UserModel User { get; set; }
    }

    public class UserModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PasswordHash { get; set; }
        public string? Phone { get; set; }
        public bool IsAdmin { get; set; }

        public List<LoanModel> Loans { get; set; }
        public List<ReviewModel> Reviews { get; set; }
    }
}
