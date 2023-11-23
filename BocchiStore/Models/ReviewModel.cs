namespace BocchiStore.Models
{
    public class ReviewModel
    {
        public int ReviewId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Score { get; set; }

        public BookModel Book { get; set; }
        public UserModel User { get; set; }
    }
}
