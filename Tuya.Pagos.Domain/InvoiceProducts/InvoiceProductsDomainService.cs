using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Tuya.Pagos.Models.Entities;
using Tuya.Pagos.Domain.Interfaces.InvoiceProducts;
using Tuya.Pagos.Persistence.Interfaces.Repositories;
using Tuya.Pagos.Persistence.Interfaces.Infraestructure;
using Microsoft.EntityFrameworkCore;
namespace Tuya.Pagos.Domain.InvoiceProducts
{
    public class InvoiceProductsDomainService: IInvoiceProductsDomainService
    {
        private readonly IRepository<InvoiceProduct> _repoInvoice;
        private readonly IRepository<Product> _repoProduct;
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceProductsDomainService(IRepository<InvoiceProduct> repoInvoice, IRepository<Product> repoProduct, IUnitOfWork unitOfWork)
        {
            _repoInvoice = repoInvoice;
            _repoProduct = repoProduct;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<int>> AssociateProductWithInvoice(int idInvoice, List<Product> products)
        {
            try
            {
                List<InvoiceProduct> invoiceProducts = new List<InvoiceProduct>();

                foreach (Product product in products)
                {
                    Product product1 = _repoProduct.GetAll().Include(p => p.Stocks).FirstOrDefault(p => p.IdProduct == product.IdProduct);
                    bool resp = _repoProduct.GetAll().Include(p => p.Stocks).Any(p => p.IdProduct == product.IdProduct && p.Stocks.Any(s => s.State == "1" ));
                    if (resp)
                    {
                        invoiceProducts.Add(new InvoiceProduct
                        {
                            IdInvoice = idInvoice,
                            IdProduct = product.IdProduct
                        });
                    }
                }

                _repoInvoice.AddRange(invoiceProducts);
                _unitOfWork.Commit();

                return await Task.FromResult(invoiceProducts.Select(ip => ip.IdProduct).ToList());
            }
            catch (System.Exception e)
            {
                return null;
            }
        }
    }
}
