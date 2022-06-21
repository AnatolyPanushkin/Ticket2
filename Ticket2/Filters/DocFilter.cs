using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ticket2.Filters
{
    public class DocFilter:Attribute, IActionFilter
    {
        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Если код типа документа соответствует паспорту гражданина РФ 
            if (context.HttpContext.Request.Query["doc_type"].ToString().Equals("00"))
            {
                //достаем из запроса номер документа и проверяем его
                var passport = context.HttpContext.Request.Query["doc_number"].ToString();
                if (passport.Length!=10)
                {
                    context.Result = new BadRequestResult();
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}