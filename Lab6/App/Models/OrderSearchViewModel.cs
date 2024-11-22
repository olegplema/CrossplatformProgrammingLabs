namespace App.Models;

public class OrderSearchViewModel
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string CustomerName { get; set; }
    public List<Order> Results { get; set; }
    public bool SearchPerformed { get; set; }
}