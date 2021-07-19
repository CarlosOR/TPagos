using System.Collections.Generic;

#nullable disable

namespace Tuya.Pagos.Models.Entities
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceProducts = new HashSet<InvoiceProduct>();
            Sendings = new HashSet<Sending>();
            Stocks = new HashSet<Stock>();
        }

        public int IdInvoice { get; set; }
        public int IdCliente { get; set; }

        public virtual Customer IdClienteNavigation { get; set; }
        public virtual ICollection<InvoiceProduct> InvoiceProducts { get; set; }
        public virtual ICollection<Sending> Sendings { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
