using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Tuya.Pagos.Filters
{
    public class ResultFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Exception is null)
            {
                context.Result = new OkObjectResult(new
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Resultado = (context.Result as OkObjectResult).Value
                });
            }
        }
    }
}
