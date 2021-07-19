using System;
using AutoMapper;
using Tuya.Pagos.Models.Dtos;
using Tuya.Pagos.Models.Entities;
using System.Collections.Generic;
using Tuya.Pagos.Domain.Interfaces.Invoices;
using Tuya.Pagos.Application.Interfaces.Invoices;
using Tuya.Pagos.Domain.Interfaces.InvoiceProducts;
using Tuya.Pagos.ExceptionsHandling.ControlExceptions.TuyaExceptions;
using System.Linq;
using Tuya.Pagos.Domain.Interfaces.Stocks;
using Tuya.Pagos.Domain.Interfaces.Sendings;
using System.Threading.Tasks;

namespace Tuya.Pagos.Application.Invoices
{
    public class InvoiceApplicationService : IInvoiceApplicationService
    {
        private readonly IInvoiceDomainService _invoiceDomain;
        private readonly IInvoiceProductsDomainService _invoiceProductsDomain;
        private readonly IStockDomainService _stockDomain;
        private readonly ISendingDomainService _sendingDomain;
        private readonly IMapper _mapper;
        public InvoiceApplicationService(
            IMapper mapper, 
            IInvoiceDomainService invoiceDomain, 
            IInvoiceProductsDomainService invoiceProductsDomain,
            IStockDomainService stockDomain,
            ISendingDomainService sendingDomain)
        {
            _invoiceDomain = invoiceDomain;
            _invoiceProductsDomain = invoiceProductsDomain;
            _stockDomain = stockDomain;
            _sendingDomain = sendingDomain;
            _mapper = mapper;
        }

        public async Task<DtoResponseInvoice> GenerateInvoice(DtoInvoice invoice)
        {
            try
            {
                int idInvoice = _invoiceDomain.GenerateInvoice(invoice.IdCliente);

                IList<int> productsIds = await _invoiceProductsDomain.AssociateProductWithInvoice(idInvoice, _mapper.Map<List<Product>>(invoice.Products));

                if (productsIds is null || productsIds.Count == 0)
                {
                    _invoiceDomain.DeleteInvoiceById(idInvoice);

                    return new DtoResponseInvoice
                    {
                        Total = 0,
                        idInvoice = 0,
                        Products = new List<DtoProducts>()
                    };
                }
                _sendingDomain.CreateSend(idInvoice);

                _stockDomain.UpdateStock(idInvoice, productsIds);

                IList<DtoProducts> productsOnStock = invoice.Products.Where(p => productsIds.Contains(p.IdProducto)).ToList();

                return await Task.FromResult(new DtoResponseInvoice()
                {
                    Total = productsOnStock.Select(p => p.Price).Aggregate((a, v) => a + v),
                    idInvoice = idInvoice,
                    Products = productsOnStock
                });
            }
            catch (Exception e)
            {
                throw new TuyaInternalException(e.Message);
            }
        }
    }
}
