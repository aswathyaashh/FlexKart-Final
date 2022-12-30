using Amazon.CodePipeline.Model;
using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using System.Net;

namespace E_Commerce.api.APILayer.CustomExceptionMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ILoggerManager _logger;

        public ExceptionMiddleware(RequestDelegate next)
        {
            //_logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var errorMessage = new ApiResponseBase
            {
                Success = false,
                Message = "An unexpected error occurred."
            };
            string result = JsonConvert.SerializeObject(errorMessage);
            return context.Response.WriteAsync(result);
        }
    }
}
