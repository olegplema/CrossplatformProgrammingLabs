namespace App.Models;

public class CreditNote
{
    public int CreditNoteId { get; set; }
    public int OrderId { get; set; }
    public DateTime CreditNoteDate { get; set; }

    public Order Order { get; set; }
    public ICollection<CreditNoteReturnItem> CreditNoteReturnItems { get; set; }
}
