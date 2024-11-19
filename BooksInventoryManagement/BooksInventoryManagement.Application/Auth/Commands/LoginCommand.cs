using BooksInventoryManagement.Application.Common.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksInventoryManagement.Application.Auth.Commands
{
    public class LoginCommand : IRequest<Authenticationvm>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
