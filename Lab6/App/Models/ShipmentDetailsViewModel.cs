namespace App.Models;

public class ShipmentDetailsViewModel
{
    public Shipment Shipment { get; set; }
    public Order OrderDetails { get; set; }
    public ICollection<ShipmentItem> ShipmentItems { get; set; }}