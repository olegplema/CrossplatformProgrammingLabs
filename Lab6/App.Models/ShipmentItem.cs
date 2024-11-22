namespace App.Models;

public class ShipmentItem
{
    public int ShipmentItemId { get; set; }
    public int ShipmentId { get; set; }
    public int OrderItemId { get; set; }

    public Shipment Shipment { get; set; }
    public OrderItem OrderItem { get; set; }
    public ICollection<CreditNoteReturnItem> CreditNoteReturnItems { get; set; }
}
