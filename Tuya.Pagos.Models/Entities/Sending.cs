
#nullable disable

namespace Tuya.Pagos.Models.Entities
{
    public partial class Sending
    {
        public int IdSending { get; set; }
        public int IdInvoice { get; set; }
        public string State { get; set; }

        public virtual Invoice IdInvoiceNavigation { get; set; }
    }
}
