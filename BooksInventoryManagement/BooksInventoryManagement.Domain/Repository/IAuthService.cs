using BooksInventoryManagement.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksInventoryManagement.Domain.Repository
{
    public interface IAuthService
    {
        Task<AuthenticationVm> LoginAsync(string email, string password);
        Task<bool> RegisterAsync(string email, string password, string role);
    }
}
