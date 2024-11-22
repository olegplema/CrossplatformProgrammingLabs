namespace App.Models;

public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public string OrderStatusCode { get; set; }
    public DateTime DateOrderPlaced { get; set; }
    public DateTime DateOrderDelivered { get; set; }
    public string OrderDetails { get; set; }

    public Customer Customer { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
    public ICollection<Shipment> Shipments { get; set; }
    public ICollection<Invoice> Invoices { get; set; }
    public ICollection<CreditNote> CreditNotes { get; set; }
}
