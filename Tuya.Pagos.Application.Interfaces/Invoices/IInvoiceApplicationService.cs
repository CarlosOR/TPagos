using System.Threading.Tasks;
using Tuya.Pagos.Models.Dtos;

namespace Tuya.Pagos.Application.Interfaces.Invoices
{
    public interface IInvoiceApplicationService
    {
        Task<DtoResponseInvoice> GenerateInvoice(DtoInvoice invoice);
    }
}
