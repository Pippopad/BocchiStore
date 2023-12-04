namespace BocchiStore.Models
{
    public struct TopBook
    {
        public int BookId { get; set; }
        public int Loans { get; set; }

        public BookModel Book { get; set; }
    }

    public class BookModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? CoverImage { get; set; }

        public List<CategoryModel> Categories { get; set; }
        public List<LoanModel> Loans { get; set; }
        public List<ReviewModel> Reviews { get; set; }
    }
}
