using BooksInventoryManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksInventoryManagement.Application.Common.Behaviours
{
    public class ExceptionHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (ValidationException ex)
            {
                // Log or process validation exceptions
                throw new ApplicationException($"Validation error: {string.Join(", ", ex.Errors)}");
            }
            catch (UnauthorizedAccessException)
            {
                throw new ApplicationException("Unauthorized access.");
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                throw new ApplicationException($"Unhandled error: {ex.Message}", ex);
            }
        }
    }
}
