using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ticket2.Filters
{
    public class DocFilter:Attribute, IActionFilter
    {
        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //context.HttpContext.Request.EnableBuffering();
            
            var reader = new StreamReader(context.HttpContext.Request.Body, 
                Encoding.UTF8, false, 2048, true);

            var jsonBody = reader.ReadToEnd();
            
            string[] requestParam = jsonBody.Split(",");

            if (requestParam[6].Equals("00"))
            {
                if (requestParam[7].Length!=10)
                {
                    context.Result = new BadRequestResult();
                }
            }
            
            //context.HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);



            /*//Если код типа документа соответствует паспорту гражданина РФ 
            if (context.HttpContext.Request.Query["doc_type"].ToString().Equals("00"))
            {
                //достаем из запроса номер документа и проверяем его
                var passport = context.HttpContext.Request.Query["doc_number"].ToString();
                if (passport.Length!=10)
                {
                    context.Result = new BadRequestResult();
                }
            }*/
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}