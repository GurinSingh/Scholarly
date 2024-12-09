using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Scholarly.Domain.Exceptions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly Logger<GlobalExceptionHandler> _logger;

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var errorResponse = new ErrorResponse
            {
                Message = exception.Message,
                Title = exception.GetType().Name
            };
            //this._logger.LogError(errorResponse.Message);

            switch (exception)
            {
                case InvalidOperationException:
                    errorResponse.StatusCode = (int)HttpStatusCode.NotFound;
                    errorResponse.Message = "The page you were looking for was not found.";
                    break;
                case UnauthorizedAccessException:
                    errorResponse.StatusCode = (int)HttpStatusCode.Unauthorized; break;
                case NullReferenceException:
                    errorResponse.StatusCode = (int)HttpStatusCode.BadRequest; break;
                case NotImplementedException:
                    errorResponse.StatusCode = (int)HttpStatusCode.NotImplemented; break;
                case BadHttpRequestException:
                    errorResponse.StatusCode = (int)HttpStatusCode.BadRequest; break;
                //case SqlExpression:
                //    errorResponse.StatusCode = (int)HttpStatusCode.InternalServerError; break;
                default:
                    errorResponse.StatusCode = (int)HttpStatusCode.InternalServerError; break;
            }

            httpContext.Response.StatusCode = errorResponse.StatusCode;

            await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);

            return true;
        }
    }
}
