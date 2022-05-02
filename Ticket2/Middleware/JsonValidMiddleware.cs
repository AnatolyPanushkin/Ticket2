using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Schema;
using Ticket2.Models;
using Ticket2.ValidationJson;


namespace Ticket2.Middleware
{
    public class JsonValidMiddleware
    {
      private readonly RequestDelegate _next;

      public JsonValidMiddleware(RequestDelegate next)
       {
         _next = next;
       }
        
        
        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().Contains("sale"))
            {
                var reader = new StreamReader(httpContext.Request.Body);
                var content = await reader.ReadToEndAsync();
                
                if (content.IsJsonValid()==false)
                {
                    throw new BadHttpRequestException("invalid fdsfsdfsd data", 400);
                }
                /*string jsonBody = httpContext.Request.Body.ToString().Replace();
              JObject jsonForValid = JObject.Parse(httpContext.Request.Body);
              
              if (!jsonForValid.IsValid(schema))
              {
                  throw new BadHttpRequestException("invalid data", 498);
              }*/
            }
            await _next(httpContext);
        }
    }
}
