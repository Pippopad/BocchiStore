namespace BocchiStore.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public List<BookModel> Books { get; set; }
    }
}
