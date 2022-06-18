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
            if (context.HttpContext.Request.Form["Doc_Type"].ToString().Equals("00"))
            {
                //достаем из запроса номер документа и проверяем его
                var pasport = context.HttpContext.Request.Form["Doc_Number"];
                if (pasport.Count!=10)
                {
                    context.Result = new BadRequestResult();
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }
    }
}