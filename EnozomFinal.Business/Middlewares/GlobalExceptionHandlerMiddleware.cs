using EnozomFinal.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EnozomFinal.Application.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleException(httpContext, ex);
            }
        }

        private Task HandleException(HttpContext httpContext, Exception exception)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = MediaTypeNames.Application.Json;
            string result = string.Empty;

            switch (exception)
            {
                case ValidationException validationException:
                    statusCode = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(new { errors = validationException.ValdationErrors });
                    break;
                case BadRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case NotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case Exception:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
            }

            httpContext.Response.StatusCode = (int)statusCode;

            if (result == string.Empty)
            {
                result = JsonSerializer.Serialize(new { errors = new List<string> { exception.Message } });
            }


            return httpContext.Response.WriteAsync(result);
        }



    }
}
