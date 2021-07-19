using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tuya.Pagos.Domain.Interfaces.Stocks
{
    public interface IStockDomainService
    {
        Task<bool> UpdateStock(int idInvoice, IList<int> idProducts);
    }
}
