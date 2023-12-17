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
    }
}
