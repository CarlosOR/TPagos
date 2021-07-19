using System.Net;

namespace Tuya.Pagos.ExceptionsHandling.ControlExceptions.TuyaExceptions
{
    public class TuyaInternalException: TuyaException
    {
        public TuyaInternalException(string message) : base(message, HttpStatusCode.InternalServerError)
        {

        }
    }
}
