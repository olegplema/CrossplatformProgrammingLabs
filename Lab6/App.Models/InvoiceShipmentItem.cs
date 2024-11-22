namespace App.Models;

public class InvoiceShipmentItem
{
    public int InvoiceShipmentItemId { get; set; }
    public int InvoiceId { get; set; }
    public int ShipmentId { get; set; }


    public Invoice Invoice { get; set; }
    public Shipment Shipment { get; set; }
}