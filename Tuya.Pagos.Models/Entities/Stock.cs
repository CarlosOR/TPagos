
#nullable disable

namespace Tuya.Pagos.Models.Entities
{
    public partial class Stock
    {
        public int IdStock { get; set; }
        public int? IdProduct { get; set; }
        public string State { get; set; }
        public int? IdInvoice { get; set; }

        public virtual Invoice IdInvoiceNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
    }
}
