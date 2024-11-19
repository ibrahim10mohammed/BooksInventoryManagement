using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksInventoryManagement.Domain.ViewModels
{
    public class AuthenticationVm
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
