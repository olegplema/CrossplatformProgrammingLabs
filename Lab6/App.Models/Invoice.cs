namespace App.Models;

public class Invoice
{
    public int InvoiceId { get; set; }
    public int OrderId { get; set; }
    public string InvoiceStatusCode { get; set; }
    public DateTime InvoiceDate { get; set; }
    public string OtherDetails { get; set; }

    public Order Order { get; set; }
    public ICollection<InvoiceShipmentItem> InvoiceShipmentItems { get; set; }
}
