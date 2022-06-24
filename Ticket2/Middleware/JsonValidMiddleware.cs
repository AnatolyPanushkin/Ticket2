using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;



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
            var jsonSchema = new JsonSchemaCreator();

            var requestString = httpContext.Request.Path.ToString()
                .Split("/");

            var schemaName = requestString[^1];
            
            httpContext.Request.EnableBuffering();

            var jsonBody = await new StreamReader(httpContext.Request.Body).ReadToEndAsync();

            httpContext.Request.Body.Seek(0, SeekOrigin.Begin);

            JObject requestJson = JObject.Parse(jsonBody);

            if (!requestJson.IsValid(jsonSchema.ReturnJSchema(schemaName)))
            {
                throw new BadHttpRequestException("invalid data", 409);
            }
            
            await _next(httpContext);
        }
    }
}
//var jsonBody = await reader.ReadToEndAsync();
/*var reader = await new StreamReader(httpContext.Request.Body,
    Encoding.UTF8, false, 2048, true).ReadToEndAsync();*/
//var json2 = JsonConvert.DeserializeObject<JObject>(httpContext.Request.Body.ToString()!);
/*var req = httpContext.Request;

               req.Body.Position = 0;
               
               StreamReader stream = new StreamReader(req.Body, Encoding.UTF8, true, 2048,true);
               
               string jsonBody = await stream.ReadToEndAsync();*/
//JObject requestJson = JObject.FromObject(httpContext.Request.BodyReader);
/*req.Body.Position = 0;*/

/*if (httpContext.Request.Path.ToString().Contains("refund"))
            {
                httpContext.Request.EnableBuffering();
                
                var reader = new StreamReader(httpContext.Request.Body,
                    Encoding.UTF8, false, 2048, true);
                
                var jsonBody = await reader.ReadToEndAsync();

                httpContext.Request.Body.Seek(0, SeekOrigin.Begin);

                JObject requestJson = JObject.Parse(jsonBody);
                
                if (!requestJson.IsValid(schemaRefund))
                {
                    throw new BadHttpRequestException("invalid data", 409);
                }
            }*/