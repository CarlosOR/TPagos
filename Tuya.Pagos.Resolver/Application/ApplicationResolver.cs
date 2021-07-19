using Tuya.Pagos.Application.Invoices;
using Microsoft.Extensions.DependencyInjection;
using Tuya.Pagos.Application.Interfaces.Invoices;

namespace Tuya.Pagos.Resolver.Application
{
    public static class ApplicationResolver
    {

        public static void AddApplicationServices(this IServiceCollection service)
        {
            service.AddScoped<IInvoiceApplicationService, InvoiceApplicationService>();
        }

    }
}
