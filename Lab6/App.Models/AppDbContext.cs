using Microsoft.EntityFrameworkCore;

namespace App.Models;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerAddress> CustomerAddresses { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Shipment> Shipments { get; set; }
    public DbSet<ShipmentItem> ShipmentItems { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceShipmentItem> InvoiceShipmentItems { get; set; }
    public DbSet<CreditNote> CreditNotes { get; set; }
    public DbSet<CreditNoteReturnItem> CreditNoteReturnItems { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerAddress>()
            .HasKey(ca => ca.CustomerAddressId);

        modelBuilder.Entity<CustomerAddress>()
            .HasOne(ca => ca.Customer)
            .WithMany(c => c.CustomerAddresses)
            .HasForeignKey(ca => ca.CustomerId);

        modelBuilder.Entity<CustomerAddress>()
            .HasOne(ca => ca.Address)
            .WithMany(a => a.CustomerAddresses)
            .HasForeignKey(ca => ca.AddressId);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Product)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(oi => oi.ProductId);

        modelBuilder.Entity<Shipment>()
            .HasOne(s => s.Order)
            .WithMany(o => o.Shipments)
            .HasForeignKey(s => s.OrderId);

        modelBuilder.Entity<ShipmentItem>()
            .HasOne(si => si.Shipment)
            .WithMany(s => s.ShipmentItems)
            .HasForeignKey(si => si.ShipmentId);

        modelBuilder.Entity<ShipmentItem>()
            .HasOne(si => si.OrderItem)
            .WithMany(oi => oi.ShipmentItems)
            .HasForeignKey(si => si.OrderItemId);

        modelBuilder.Entity<Invoice>()
            .HasOne(i => i.Order)
            .WithMany(o => o.Invoices)
            .HasForeignKey(i => i.OrderId);

        modelBuilder.Entity<InvoiceShipmentItem>()
            .HasOne(isi => isi.Invoice)
            .WithMany(i => i.InvoiceShipmentItems)
            .HasForeignKey(isi => isi.InvoiceId);
        
        modelBuilder.Entity<CreditNote>()
            .HasOne(cn => cn.Order)
            .WithMany(o => o.CreditNotes)
            .HasForeignKey(cn => cn.OrderId);

        modelBuilder.Entity<CreditNoteReturnItem>()
            .HasOne(cnri => cnri.CreditNote)
            .WithMany(cn => cn.CreditNoteReturnItems)
            .HasForeignKey(cnri => cnri.CreditNoteId);

        modelBuilder.Entity<CreditNoteReturnItem>()
            .HasOne(cnri => cnri.ShipmentItem)
            .WithMany(si => si.CreditNoteReturnItems)
            .HasForeignKey(cnri => cnri.ShipmentItemId);
        DatabaseSeeder.SeedDatabase(modelBuilder);
    }
}
