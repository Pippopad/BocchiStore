using BocchiStore.Models;
using BocchiStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BocchiStore.Pages
{
    public class UsersModel : PageModel
    {
        private readonly IStorage _storage;

        public UsersModel(IStorage storage)
        {
            _storage = storage;
        }

        public void OnGet()
        {
        }

        public List<UserModel> Users => _storage.GetUsers().ToList();

        public static implicit operator UsersModel?(UserModel? v)
        {
            throw new NotImplementedException();
        }
    }
}
