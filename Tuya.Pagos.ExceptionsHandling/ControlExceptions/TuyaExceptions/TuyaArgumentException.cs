using System.Net;

namespace Tuya.Pagos.ExceptionsHandling.ControlExceptions.TuyaExceptions
{
    public class TuyaArgumentException: TuyaException
    {
        public TuyaArgumentException(string message) : base(message, HttpStatusCode.BadRequest)
        {

        }
    }
}
