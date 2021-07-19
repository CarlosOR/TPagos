using Tuya.Pagos.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Tuya.Pagos.Application.Interfaces.Invoices;

namespace Tuya.Pagos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceApplicationService _invoiceApplication;
        public InvoiceController(IInvoiceApplicationService invoiceApplication)
        {
            _invoiceApplication = invoiceApplication;
        }

        [HttpPost]
        [Route(nameof(InvoiceController.GenerateInvoice))]
        public ActionResult<DtoResponseInvoice> GenerateInvoice(DtoInvoice invoice)
        {
            int x = 0;
            int y = 3 / x;
            return Ok(_invoiceApplication.GenerateInvoice(invoice));
        }
    }
}
