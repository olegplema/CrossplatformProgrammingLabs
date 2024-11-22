namespace App.Models;

public class Customer
{
    public int CustomerId { get; set; }
    public string GenderCode { get; set; }
    public string OrganisationOrPerson { get; set; }
    public string OrganisationName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string LoginName { get; set; }
    public string LoginPassword { get; set; }
    public string PhoneNumber { get; set; }
    public string OtherDetails { get; set; }

    public ICollection<CustomerAddress> CustomerAddresses { get; set; }
    public ICollection<Order> Orders { get; set; }
}
