using System.Threading.Tasks;
using Tuya.Pagos.Models.Entities;
using Tuya.Pagos.Domain.Interfaces.Sendings;
using Tuya.Pagos.Persistence.Interfaces.Repositories;
using Tuya.Pagos.Persistence.Interfaces.Infraestructure;

namespace Tuya.Pagos.Domain.Sendings
{
    public class SendingDomainService : ISendingDomainService
    {
        private readonly IRepository<Sending> _repoSending;
        private readonly IUnitOfWork _unitOfWork;
        public SendingDomainService(IRepository<Sending> repoSending, IUnitOfWork unitOfWork)
        {
            _repoSending = repoSending;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateSend(int idInvoice)
        {
            Sending newSending = new Sending
            {
                IdInvoice = idInvoice
            };
            _repoSending.Save(newSending);
            _unitOfWork.Commit();
            return await Task.FromResult(true);
        }
    }
}
