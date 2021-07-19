using Microsoft.EntityFrameworkCore;
using Tuya.Pagos.Models.Entities;

namespace Tuya.Pagos.Persistence.Context
{
    public partial class PagosContext : DbContext
    {
        public PagosContext()
        {
        }

        public PagosContext(DbContextOptions<PagosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceProduct> InvoiceProducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sending> Sendings { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("PK__Customer__C1961B330FAC74AB");

                entity.ToTable("Customer");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.IdInvoice)
                    .HasName("PK__Invoice__4AFC50A482B1CFC4");

                entity.ToTable("Invoice");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Invoice__IdClien__286302EC");
            });

            modelBuilder.Entity<InvoiceProduct>(entity =>
            {
                entity.HasKey(e => e.IdInvoiceProduct)
                    .HasName("PK__InvoiceP__2789F0117685CCE5");

                entity.ToTable("InvoiceProduct");

                entity.HasOne(d => d.IdInvoiceNavigation)
                    .WithMany(p => p.InvoiceProducts)
                    .HasForeignKey(d => d.IdInvoice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__InvoicePr__IdInv__2B3F6F97");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.InvoiceProducts)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__InvoicePr__IdPro__2C3393D0");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK__Product__2E8946D4A913D74D");

                entity.ToTable("Product");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Reference)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sending>(entity =>
            {
                entity.HasKey(e => e.IdSending)
                    .HasName("PK__Sending__4C8024D844B464A8");

                entity.ToTable("Sending");

                entity.Property(e => e.State)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdInvoiceNavigation)
                    .WithMany(p => p.Sendings)
                    .HasForeignKey(d => d.IdInvoice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sending__IdInvoi__32E0915F");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.IdStock)
                    .HasName("PK__Stock__A4B76DE50B90EF57");

                entity.ToTable("Stock");

                entity.Property(e => e.IdStock).HasColumnName("idStock");

                entity.Property(e => e.State)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdInvoiceNavigation)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.IdInvoice)
                    .HasConstraintName("FK__Stock__IdInvoice__300424B4");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Stock__IdProduct__2F10007B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
