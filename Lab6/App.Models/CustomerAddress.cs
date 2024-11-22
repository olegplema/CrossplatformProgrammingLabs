namespace App.Models;

public class CustomerAddress
{
    public int CustomerAddressId { get; set; }
    public int CustomerId { get; set; }
    public int AddressId { get; set; }
    public string AddressTypeCode { get; set; }
    public DateTime? DateMovedIn { get; set; }
    public DateTime? DateMovedOut { get; set; }

    public Customer Customer { get; set; }
    public Address Address { get; set; }
}
