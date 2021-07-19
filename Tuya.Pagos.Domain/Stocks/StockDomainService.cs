using System.Linq;
using System.Collections.Generic;
using Tuya.Pagos.Models.Entities;
using Tuya.Pagos.Domain.Interfaces.Stocks;
using Tuya.Pagos.Persistence.Interfaces.Repositories;
using Tuya.Pagos.Persistence.Interfaces.Infraestructure;
using System.Threading.Tasks;

namespace Tuya.Pagos.Domain.Stocks
{
    public class StockDomainService: IStockDomainService
    {
        private readonly IRepository<Stock> _repoStock;
        private readonly IUnitOfWork _unitOfWork;
        public StockDomainService(IRepository<Stock> repoStock, IUnitOfWork unitOfWork)
        {
            _repoStock = repoStock;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> UpdateStock(int idInvoice, IList<int> idProducts)
        {
            foreach (int id in idProducts)
            {
                Stock stock = _repoStock.GetAll().FirstOrDefault(s => s.IdProduct == id);
                stock.State = "2";
                stock.IdInvoice = idInvoice;
                _repoStock.Update(stock);
            }
            _unitOfWork.Commit();
            return await Task.FromResult(true);
        }
    }
}
