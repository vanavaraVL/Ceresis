using Ceresis.Data.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Ceresis.Common
{
    public class CustomExceptionHandler
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Контролируемые ошибки
            if (exception is CeresisException ceresisException)
            {
                var result = JsonConvert.SerializeObject(new {
                    StatusCode = ceresisException.HttpStatus,
                    Error = exception.Message
                });
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)ceresisException.HttpStatus;
                return context.Response.WriteAsync(result);
            }
            else
            {
                var result = JsonConvert.SerializeObject(new {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Error = exception.Message
                });
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return context.Response.WriteAsync(result);
            }
        }
    }
}