using BocchiStore.Pages;

namespace BocchiStore.Models
{
    public struct LoanModelFull
    {
        public BookModel Book { get; set; }
        public UserModel User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class LoanModel
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
