﻿using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

namespace WebApi.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            
            var watch = Stopwatch.StartNew(); // Create new timer
            try
            {
                // Request
                string req_message = "[Request]  Method: " + context.Request.Method + " - Path: " + context.Request.Path;
                Debug.WriteLine(req_message);
                await _next(context);

                // Response
                watch.Stop(); // Stop timer
                string res_message = "[Response] Method: " + context.Request.Method + " - Path: " + context.Request.Path
                    + " - Status Code :" + context.Response.StatusCode + " | finished in " + watch.Elapsed.TotalMilliseconds + " ms";
                Debug.WriteLine(res_message);
            }
            catch (Exception e)
            {
                watch.Stop();
                await HandleException(e,context,watch);
            }
        }

        private Task HandleException(Exception e, HttpContext context, Stopwatch watch)
        {
            string message = "[Error]   Method:" + context.Request.Method + " - Status Code: " + context.Response.StatusCode
                + " - Error Message:" + e.Message + " | finished in " + watch.Elapsed.TotalMilliseconds + " ms";
            Debug.WriteLine(message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var result = JsonConvert.SerializeObject(new { error = e.Message }, Formatting.None);

            return context.Response.WriteAsync(result);
        }
    }

    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
