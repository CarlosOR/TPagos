using System.Collections.Generic;

namespace Tuya.Pagos.Models.Dtos
{
    public class DtoInvoice
    {
        public int IdCliente { get; set; }
        public IList<DtoProducts> Products { get; set; }
    }

}
