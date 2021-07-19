using Microsoft.EntityFrameworkCore;

namespace Tuya.Pagos.Persistence.Interfaces.Infraestructure
{
    public interface IContructorConnection
    {
        //U can get by params IServiceProvider if u need some service
        void ConfigureConnection(DbContextOptionsBuilder builder);
    }
}
