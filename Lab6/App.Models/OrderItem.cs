namespace App.Models;

public class OrderItem
{
    public int OrderItemId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public string OrderItemStatusCode { get; set; }
    public int OrderItemQuantity { get; set; }
    public decimal OrderItemPrice { get; set; }
    public string OtherDetails { get; set; }

    public Order Order { get; set; }
    public Product Product { get; set; }
    public ICollection<CreditNoteReturnItem> CreditNoteReturnItems { get; set; }
    public ICollection<ShipmentItem> ShipmentItems { get; set; }
}

