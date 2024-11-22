namespace App.Models;


public class CreditNoteReturnItem
{
    public int CreditNoteReturnItemId { get; set; }
    public int CreditNoteId { get; set; }
    public int ShipmentItemId { get; set; }

    public CreditNote CreditNote { get; set; }
    public ShipmentItem ShipmentItem { get; set; }
}