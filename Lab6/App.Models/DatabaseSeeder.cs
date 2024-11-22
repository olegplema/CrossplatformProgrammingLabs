using Microsoft.EntityFrameworkCore;

namespace App.Models;

public static class DatabaseSeeder
{
    public static void SeedDatabase(ModelBuilder modelBuilder)
    {
        // Seed Addresses
        modelBuilder.Entity<Address>().HasData(
            new Address
            {
                AddressId = 1,
                AddressLine1 = "123 Main St",
                AddressLine2 = "Apt 101",
                AddressLine3 = "",
                AddressLine4 = "",
                TownCity = "Springfield",
                ZipPostcode = "12345",
                StateProvinceCounty = "Illinois",
                Country = "USA"
            },
            new Address
            {
                AddressId = 2,
                AddressLine1 = "456 Elm St",
                AddressLine2 = "Suite 202",
                AddressLine3 = "",
                AddressLine4 = "",
                TownCity = "Metropolis",
                ZipPostcode = "67890",
                StateProvinceCounty = "New York",
                Country = "USA"
            }
        );
        
        // Seed Customers
        modelBuilder.Entity<Customer>().HasData(
            new Customer
            {
                CustomerId = 1,
                GenderCode = "M",
                OrganisationOrPerson = "Person", 
                OrganisationName = "Organisaton A",
                FirstName = "John",
                MiddleName = "", 
                LastName = "Doe",
                EmailAddress = "john.doe@example.com",
                LoginName = "johndoe",
                LoginPassword = "password123",
                PhoneNumber = "555-1234",
                OtherDetails = "John is a regular customer with no additional details."
            },
            new Customer
            {
                CustomerId = 2,
                GenderCode = "F",
                OrganisationOrPerson = "Person",
                OrganisationName = "Organisaton B",
                FirstName = "Jane",
                MiddleName = "", 
                LastName = "Smith",
                EmailAddress = "jane.smith@example.com",
                LoginName = "janesmith",
                LoginPassword = "password456",
                PhoneNumber = "555-5678",
                OtherDetails = "Jane is a new customer, eager to engage with our services."
            }
        );

        // Seed Products
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                ProductId = 1,
                ProductName = "Widget A",
                ProductPrice = 19.99m,
                ProductColor = "Red",
                ProductSize = "M",
                ProductDescription = "High quality widget"
            },
            new Product
            {
                ProductId = 2,
                ProductName = "Widget B",
                ProductPrice = 24.99m,
                ProductColor = "Blue",
                ProductSize = "L",
                ProductDescription = "Durable widget"
            }
        );

        // Seed Orders
        modelBuilder.Entity<Order>().HasData(
            new Order
            {
                OrderId = 1,
                CustomerId = 1,
                OrderStatusCode = "Pending",
                DateOrderPlaced = DateTime.Now.AddDays(-2),
                DateOrderDelivered = DateTime.Now.AddDays(3),
                OrderDetails = "First Order Details"
            },
            new Order
            {
                OrderId = 2,
                CustomerId = 2,
                OrderStatusCode = "Shipped",
                DateOrderPlaced = DateTime.Now.AddDays(-5),
                DateOrderDelivered = DateTime.Now.AddDays(-1),
                OrderDetails = "Second Order Details"
            }
        );

        // Seed OrderItems
        modelBuilder.Entity<OrderItem>().HasData(
            new OrderItem
            {
                OrderItemId = 1,
                OrderId = 1,
                ProductId = 1,
                OrderItemStatusCode = "Delivered",
                OrderItemQuantity = 2,
                OrderItemPrice = 19.99m,
                OtherDetails = "This item was delivered successfully." // Non-empty default value
            },
            new OrderItem
            {
                OrderItemId = 2,
                OrderId = 2,
                ProductId = 2,
                OrderItemStatusCode = "Pending",
                OrderItemQuantity = 1,
                OrderItemPrice = 24.99m,
                OtherDetails = "This item is still pending shipment." // Non-empty default value
            }
        );
        
        // Seed Shipments
        modelBuilder.Entity<Shipment>().HasData(
            new Shipment
            {
                ShipmentId = 1,
                OrderId = 1,
                TrackingNumber = "TRACK12345",
                DateShipped = DateTime.Now.AddDays(-1),
                OtherDetails = "Shipped via FedEx"
            },
            new Shipment
            {
                ShipmentId = 2,
                OrderId = 2,
                TrackingNumber = "TRACK67890",
                DateShipped = DateTime.Now,
                OtherDetails = "Shipped via UPS"
            }
        );

        // Seed ShipmentItems
        modelBuilder.Entity<ShipmentItem>().HasData(
            new ShipmentItem
            {
                ShipmentItemId = 1,
                ShipmentId = 1,
                OrderItemId = 1
            },
            new ShipmentItem
            {
                ShipmentItemId = 2,
                ShipmentId = 2,
                OrderItemId = 2
            }
        );

        // Seed Invoices
        modelBuilder.Entity<Invoice>().HasData(
            new Invoice
            {
                InvoiceId = 1,
                OrderId = 1,
                InvoiceStatusCode = "Paid",
                InvoiceDate = DateTime.Now.AddDays(-1),
                OtherDetails = "Invoice for Order 1"
            }
        );

        // Seed CreditNotes
        modelBuilder.Entity<CreditNote>().HasData(
            new CreditNote
            {
                CreditNoteId = 1,
                OrderId = 2,
                CreditNoteDate = DateTime.Now.AddDays(-1)
            }
        );
    }
}