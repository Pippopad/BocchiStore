using BocchiStore.Pages;

namespace BocchiStore.Models
{
    public struct LoanOnGoingModel
    {
        public BookModel Book { get; set; }
        public UsersModel User { get; set; }
        public DateTime StartDate { get; set; }
    }

    public class LoanModel
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
