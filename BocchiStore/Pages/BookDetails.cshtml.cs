using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BocchiStore.Pages
{
    public class BookDetailsModel : PageModel
    {
        public void OnGet(int id)
        {
            BookId = id;
        }

        public int BookId { get; set; }
    }
}
