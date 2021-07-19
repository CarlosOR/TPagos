
using System;
using System.Net;

namespace Tuya.Pagos.ExceptionsHandling.ControlExceptions
{
    public class TuyaException : Exception
    {
        public HttpStatusCode StatusCode;
        public TuyaException(string message) : base(message)
        {

        }
        
        public TuyaException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
