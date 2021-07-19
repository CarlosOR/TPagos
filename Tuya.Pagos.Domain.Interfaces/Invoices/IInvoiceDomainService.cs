
namespace Tuya.Pagos.Domain.Interfaces.Invoices
{
    public interface IInvoiceDomainService
    {
        int GenerateInvoice(int idCliente);
        bool DeleteInvoiceById(int idInvoice);
    }
}
