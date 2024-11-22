namespace App.Models;

public class Address
{
    public int AddressId { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string AddressLine3 { get; set; }
    public string AddressLine4 { get; set; }
    public string TownCity { get; set; }
    public string ZipPostcode { get; set; }
    public string StateProvinceCounty { get; set; }
    public string Country { get; set; }

    public ICollection<CustomerAddress> CustomerAddresses { get; set; }
}
