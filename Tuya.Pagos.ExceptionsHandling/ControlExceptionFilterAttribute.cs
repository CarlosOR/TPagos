using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tuya.Pagos.ExceptionsHandling.ControlExceptions;

namespace Tuya.Pagos.ExceptionsHandling
{
    public class ControlExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is TuyaException tuyaException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Exception = null;
                context.Result = new ObjectResult(new
                {
                    tuyaException.Message,
                    tuyaException.StatusCode
                });
            }
            else
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                context.Result = new ObjectResult(new
                {
                    Mensaje = "Internal Error"
                });
            }
        }
    }
}
