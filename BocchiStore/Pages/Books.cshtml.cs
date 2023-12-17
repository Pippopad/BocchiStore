using BocchiStore.Models;
using BocchiStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BocchiStore.Pages
{
    public class BooksModel : PageModel
    {
        private readonly IStorage _storage;

        public BooksModel(IStorage storage)
        {
            _storage = storage;
        }

        public void OnGet()
        {
        }

        public List<BookModel> Books => _storage.GetBooks().ToList();
    }
}
