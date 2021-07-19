using System.Collections.Generic;
using Tuya.Pagos.Models.Entities;
using Tuya.Pagos.Domain.Interfaces.Invoices;
using Tuya.Pagos.Persistence.Interfaces.Repositories;
using Tuya.Pagos.Persistence.Interfaces.Infraestructure;

namespace Tuya.Pagos.Domain.Invoices
{
    public class InvoiceDomainService : IInvoiceDomainService
    {
        private readonly IRepository<Invoice> _repoInvoice;
        private readonly IUnitOfWork _unitOfWork;
        public InvoiceDomainService(IRepository<Invoice> repoInvoice, IUnitOfWork unitOfWork)
        {
            _repoInvoice = repoInvoice;
            _unitOfWork = unitOfWork;
        }

        public int GenerateInvoice(int idCliente)
        {
            Invoice newInvoice = new Invoice()
            {
                IdCliente = idCliente,

            };

            _repoInvoice.Save(newInvoice);
            _unitOfWork.Commit();

            return newInvoice.IdInvoice;
        }

        public bool DeleteInvoiceById(int idInvoice)
        {
            Invoice invoice = _repoInvoice.GetById(idInvoice);

            _repoInvoice.Delete(invoice);
            _unitOfWork.Commit();
            return true;
        }
    }
}
