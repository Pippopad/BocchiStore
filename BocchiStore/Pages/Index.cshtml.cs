using BocchiStore.Models;
using BocchiStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BocchiStore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IStorage _storage;

        public IndexModel(IStorage storage)
        {
            _storage = storage;
        }

        public void OnGet()
        {
        }

        public List<Top3User> Top3Users => _storage.GetTop3Users().ToList();
        public List<TopBook> TopBooks => _storage.GetTopBooks().ToList();
    }
}