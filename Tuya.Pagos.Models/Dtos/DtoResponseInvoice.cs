using System.Collections.Generic;

namespace Tuya.Pagos.Models.Dtos
{
    public class DtoResponseInvoice
    {
        public int idInvoice { get; set; }
        public IList<DtoProducts> Products { get; set; }
        public int Total { get; set; }
    }
}
