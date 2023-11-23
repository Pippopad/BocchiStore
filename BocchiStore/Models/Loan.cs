namespace BocchiStore.Models
{
    public class Loan
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public BookModel Book { get; set; }
        public UserModel User { get; set; }
    }
}
