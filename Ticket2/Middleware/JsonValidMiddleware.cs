using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
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
            var schemaSale = JSchema.Parse(File.ReadAllText("JsonShema.txt"));

            var schemaRefund = JSchema.Parse(File.ReadAllText("JsonSchemaRefund.txt"));

            if (httpContext.Request.Path.ToString().Contains("sale"))
            {
                
                JObject requestJson = JObject.FromObject(httpContext.Request.BodyReader);
                if (requestJson.IsValid(schemaSale))
                {
                    await _next(httpContext);
                }
            }

            else if (httpContext.Request.Path.ToString().Contains("refund"))
            {
                JObject requestJson = JObject.FromObject(httpContext.Request.Body);
                
                if (requestJson.IsValid(schemaRefund ))
                {
                    await _next(httpContext);
                }
            }
            else
            {
                throw new BadHttpRequestException("invalid data", 409);  
            }

            
        }
    }
}
