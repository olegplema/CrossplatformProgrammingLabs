namespace App.Models;

public class Shipment
{
    public int ShipmentId { get; set; }
    public int OrderId { get; set; }
    public string TrackingNumber { get; set; }
    public DateTime DateShipped { get; set; }
    public string OtherDetails { get; set; }

    public Order Order { get; set; }
    public ICollection<ShipmentItem> ShipmentItems { get; set; }
}
