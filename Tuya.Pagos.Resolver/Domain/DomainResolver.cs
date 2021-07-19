using Tuya.Pagos.Domain.Invoices;
using Tuya.Pagos.Domain.Interfaces.Invoices;
using Microsoft.Extensions.DependencyInjection;
using Tuya.Pagos.Domain.Interfaces.Sendings;
using Tuya.Pagos.Domain.Sendings;
using Tuya.Pagos.Domain.Interfaces.InvoiceProducts;
using Tuya.Pagos.Domain.InvoiceProducts;
using Tuya.Pagos.Domain.Interfaces.Stocks;
using Tuya.Pagos.Domain.Stocks;

namespace Tuya.Pagos.Resolver.Domain
{
    public static class DomainResolver
    {
        public static void AddDomainServices(this IServiceCollection service)
        {
            service.AddScoped<IInvoiceDomainService, InvoiceDomainService>();
            service.AddScoped<IStockDomainService, StockDomainService>();
            service.AddScoped<IInvoiceProductsDomainService, InvoiceProductsDomainService>();
            service.AddScoped<ISendingDomainService, SendingDomainService>();
        }
    }
}
