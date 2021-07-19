using System.Collections.Generic;

#nullable disable

namespace Tuya.Pagos.Models.Entities
{
    public partial class Product
    {
        public Product()
        {
            InvoiceProducts = new HashSet<InvoiceProduct>();
            Stocks = new HashSet<Stock>();
        }

        public int IdProduct { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public string Reference { get; set; }

        public virtual ICollection<InvoiceProduct> InvoiceProducts { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
