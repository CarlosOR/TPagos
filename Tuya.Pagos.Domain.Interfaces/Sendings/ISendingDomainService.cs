

using System.Threading.Tasks;

namespace Tuya.Pagos.Domain.Interfaces.Sendings
{
    public interface ISendingDomainService
    {
        Task<bool> CreateSend(int idInvoice);
    }
}
