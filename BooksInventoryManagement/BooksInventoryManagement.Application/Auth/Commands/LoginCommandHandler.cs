using BooksInventoryManagement.Application.Common.ViewModels;
using BooksInventoryManagement.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksInventoryManagement.Application.Auth.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Authenticationvm>
    {
        private readonly IAuthService _authService;

        public LoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<Authenticationvm> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var authResults =  await _authService.LoginAsync(request.Email, request.Password);
            return new Authenticationvm
            {
                RefreshToken = authResults.RefreshToken,
                AccessToken = authResults.AccessToken,
            };
        }
    }
}
