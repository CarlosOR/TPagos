using System.Collections.Generic;
using System.Threading.Tasks;
using Tuya.Pagos.Models.Entities;

namespace Tuya.Pagos.Domain.Interfaces.InvoiceProducts
{
    public interface IInvoiceProductsDomainService
    {
        Task<IList<int>> AssociateProductWithInvoice(int idInvoice, List<Product> products);
    }
}
