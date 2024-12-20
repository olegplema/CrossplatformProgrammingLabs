﻿// <auto-generated />
using System;
using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace App.Postgres.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("App.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AddressId"));

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AddressLine2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AddressLine3")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AddressLine4")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StateProvinceCounty")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TownCity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ZipPostcode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            AddressId = 1,
                            AddressLine1 = "123 Main St",
                            AddressLine2 = "Apt 101",
                            AddressLine3 = "",
                            AddressLine4 = "",
                            Country = "USA",
                            StateProvinceCounty = "Illinois",
                            TownCity = "Springfield",
                            ZipPostcode = "12345"
                        },
                        new
                        {
                            AddressId = 2,
                            AddressLine1 = "456 Elm St",
                            AddressLine2 = "Suite 202",
                            AddressLine3 = "",
                            AddressLine4 = "",
                            Country = "USA",
                            StateProvinceCounty = "New York",
                            TownCity = "Metropolis",
                            ZipPostcode = "67890"
                        });
                });

            modelBuilder.Entity("App.Models.CreditNote", b =>
                {
                    b.Property<int>("CreditNoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CreditNoteId"));

                    b.Property<DateTime>("CreditNoteDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.HasKey("CreditNoteId");

                    b.HasIndex("OrderId");

                    b.ToTable("CreditNotes");

                    b.HasData(
                        new
                        {
                            CreditNoteId = 1,
                            CreditNoteDate = new DateTime(2024, 11, 21, 23, 14, 15, 475, DateTimeKind.Local).AddTicks(8950),
                            OrderId = 2
                        });
                });

            modelBuilder.Entity("App.Models.CreditNoteReturnItem", b =>
                {
                    b.Property<int>("CreditNoteReturnItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CreditNoteReturnItemId"));

                    b.Property<int>("CreditNoteId")
                        .HasColumnType("integer");

                    b.Property<int?>("OrderItemId")
                        .HasColumnType("integer");

                    b.Property<int>("ShipmentItemId")
                        .HasColumnType("integer");

                    b.HasKey("CreditNoteReturnItemId");

                    b.HasIndex("CreditNoteId");

                    b.HasIndex("OrderItemId");

                    b.HasIndex("ShipmentItemId");

                    b.ToTable("CreditNoteReturnItems");
                });

            modelBuilder.Entity("App.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GenderCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LoginName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LoginPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OrganisationName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OrganisationOrPerson")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OtherDetails")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            EmailAddress = "john.doe@example.com",
                            FirstName = "John",
                            GenderCode = "M",
                            LastName = "Doe",
                            LoginName = "johndoe",
                            LoginPassword = "password123",
                            MiddleName = "",
                            OrganisationName = "Organisaton A",
                            OrganisationOrPerson = "Person",
                            OtherDetails = "John is a regular customer with no additional details.",
                            PhoneNumber = "555-1234"
                        },
                        new
                        {
                            CustomerId = 2,
                            EmailAddress = "jane.smith@example.com",
                            FirstName = "Jane",
                            GenderCode = "F",
                            LastName = "Smith",
                            LoginName = "janesmith",
                            LoginPassword = "password456",
                            MiddleName = "",
                            OrganisationName = "Organisaton B",
                            OrganisationOrPerson = "Person",
                            OtherDetails = "Jane is a new customer, eager to engage with our services.",
                            PhoneNumber = "555-5678"
                        });
                });

            modelBuilder.Entity("App.Models.CustomerAddress", b =>
                {
                    b.Property<int>("CustomerAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CustomerAddressId"));

                    b.Property<int>("AddressId")
                        .HasColumnType("integer");

                    b.Property<string>("AddressTypeCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DateMovedIn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateMovedOut")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("CustomerAddressId");

                    b.HasIndex("AddressId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerAddresses");
                });

            modelBuilder.Entity("App.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("InvoiceId"));

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("InvoiceStatusCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<string>("OtherDetails")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("InvoiceId");

                    b.HasIndex("OrderId");

                    b.ToTable("Invoices");

                    b.HasData(
                        new
                        {
                            InvoiceId = 1,
                            InvoiceDate = new DateTime(2024, 11, 21, 23, 14, 15, 475, DateTimeKind.Local).AddTicks(8940),
                            InvoiceStatusCode = "Paid",
                            OrderId = 1,
                            OtherDetails = "Invoice for Order 1"
                        });
                });

            modelBuilder.Entity("App.Models.InvoiceShipmentItem", b =>
                {
                    b.Property<int>("InvoiceShipmentItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("InvoiceShipmentItemId"));

                    b.Property<int>("InvoiceId")
                        .HasColumnType("integer");

                    b.Property<int>("ShipmentId")
                        .HasColumnType("integer");

                    b.HasKey("InvoiceShipmentItemId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ShipmentId");

                    b.ToTable("InvoiceShipmentItems");
                });

            modelBuilder.Entity("App.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateOrderDelivered")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateOrderPlaced")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("OrderDetails")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OrderStatusCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            CustomerId = 1,
                            DateOrderDelivered = new DateTime(2024, 11, 25, 23, 14, 15, 475, DateTimeKind.Local).AddTicks(8860),
                            DateOrderPlaced = new DateTime(2024, 11, 20, 23, 14, 15, 475, DateTimeKind.Local).AddTicks(8800),
                            OrderDetails = "First Order Details",
                            OrderStatusCode = "Pending"
                        },
                        new
                        {
                            OrderId = 2,
                            CustomerId = 2,
                            DateOrderDelivered = new DateTime(2024, 11, 21, 23, 14, 15, 475, DateTimeKind.Local).AddTicks(8870),
                            DateOrderPlaced = new DateTime(2024, 11, 17, 23, 14, 15, 475, DateTimeKind.Local).AddTicks(8860),
                            OrderDetails = "Second Order Details",
                            OrderStatusCode = "Shipped"
                        });
                });

            modelBuilder.Entity("App.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderItemId"));

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<decimal>("OrderItemPrice")
                        .HasColumnType("numeric");

                    b.Property<int>("OrderItemQuantity")
                        .HasColumnType("integer");

                    b.Property<string>("OrderItemStatusCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OtherDetails")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("OrderItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            OrderItemId = 1,
                            OrderId = 1,
                            OrderItemPrice = 19.99m,
                            OrderItemQuantity = 2,
                            OrderItemStatusCode = "Delivered",
                            OtherDetails = "This item was delivered successfully.",
                            ProductId = 1
                        },
                        new
                        {
                            OrderItemId = 2,
                            OrderId = 2,
                            OrderItemPrice = 24.99m,
                            OrderItemQuantity = 1,
                            OrderItemStatusCode = "Pending",
                            OtherDetails = "This item is still pending shipment.",
                            ProductId = 2
                        });
                });

            modelBuilder.Entity("App.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductId"));

                    b.Property<int?>("ParentProductId")
                        .HasColumnType("integer");

                    b.Property<string>("ProductColor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("numeric");

                    b.Property<string>("ProductSize")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ProductColor = "Red",
                            ProductDescription = "High quality widget",
                            ProductName = "Widget A",
                            ProductPrice = 19.99m,
                            ProductSize = "M"
                        },
                        new
                        {
                            ProductId = 2,
                            ProductColor = "Blue",
                            ProductDescription = "Durable widget",
                            ProductName = "Widget B",
                            ProductPrice = 24.99m,
                            ProductSize = "L"
                        });
                });

            modelBuilder.Entity("App.Models.Shipment", b =>
                {
                    b.Property<int>("ShipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ShipmentId"));

                    b.Property<DateTime>("DateShipped")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<string>("OtherDetails")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TrackingNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ShipmentId");

                    b.HasIndex("OrderId");

                    b.ToTable("Shipments");

                    b.HasData(
                        new
                        {
                            ShipmentId = 1,
                            DateShipped = new DateTime(2024, 11, 21, 23, 14, 15, 475, DateTimeKind.Local).AddTicks(8900),
                            OrderId = 1,
                            OtherDetails = "Shipped via FedEx",
                            TrackingNumber = "TRACK12345"
                        },
                        new
                        {
                            ShipmentId = 2,
                            DateShipped = new DateTime(2024, 11, 22, 23, 14, 15, 475, DateTimeKind.Local).AddTicks(8910),
                            OrderId = 2,
                            OtherDetails = "Shipped via UPS",
                            TrackingNumber = "TRACK67890"
                        });
                });

            modelBuilder.Entity("App.Models.ShipmentItem", b =>
                {
                    b.Property<int>("ShipmentItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ShipmentItemId"));

                    b.Property<int>("OrderItemId")
                        .HasColumnType("integer");

                    b.Property<int>("ShipmentId")
                        .HasColumnType("integer");

                    b.HasKey("ShipmentItemId");

                    b.HasIndex("OrderItemId");

                    b.HasIndex("ShipmentId");

                    b.ToTable("ShipmentItems");

                    b.HasData(
                        new
                        {
                            ShipmentItemId = 1,
                            OrderItemId = 1,
                            ShipmentId = 1
                        },
                        new
                        {
                            ShipmentItemId = 2,
                            OrderItemId = 2,
                            ShipmentId = 2
                        });
                });

            modelBuilder.Entity("App.Models.CreditNote", b =>
                {
                    b.HasOne("App.Models.Order", "Order")
                        .WithMany("CreditNotes")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("App.Models.CreditNoteReturnItem", b =>
                {
                    b.HasOne("App.Models.CreditNote", "CreditNote")
                        .WithMany("CreditNoteReturnItems")
                        .HasForeignKey("CreditNoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.OrderItem", null)
                        .WithMany("CreditNoteReturnItems")
                        .HasForeignKey("OrderItemId");

                    b.HasOne("App.Models.ShipmentItem", "ShipmentItem")
                        .WithMany("CreditNoteReturnItems")
                        .HasForeignKey("ShipmentItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreditNote");

                    b.Navigation("ShipmentItem");
                });

            modelBuilder.Entity("App.Models.CustomerAddress", b =>
                {
                    b.HasOne("App.Models.Address", "Address")
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.Customer", "Customer")
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("App.Models.Invoice", b =>
                {
                    b.HasOne("App.Models.Order", "Order")
                        .WithMany("Invoices")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("App.Models.InvoiceShipmentItem", b =>
                {
                    b.HasOne("App.Models.Invoice", "Invoice")
                        .WithMany("InvoiceShipmentItems")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.Shipment", "Shipment")
                        .WithMany()
                        .HasForeignKey("ShipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Shipment");
                });

            modelBuilder.Entity("App.Models.Order", b =>
                {
                    b.HasOne("App.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("App.Models.OrderItem", b =>
                {
                    b.HasOne("App.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("App.Models.Shipment", b =>
                {
                    b.HasOne("App.Models.Order", "Order")
                        .WithMany("Shipments")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("App.Models.ShipmentItem", b =>
                {
                    b.HasOne("App.Models.OrderItem", "OrderItem")
                        .WithMany("ShipmentItems")
                        .HasForeignKey("OrderItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.Shipment", "Shipment")
                        .WithMany("ShipmentItems")
                        .HasForeignKey("ShipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderItem");

                    b.Navigation("Shipment");
                });

            modelBuilder.Entity("App.Models.Address", b =>
                {
                    b.Navigation("CustomerAddresses");
                });

            modelBuilder.Entity("App.Models.CreditNote", b =>
                {
                    b.Navigation("CreditNoteReturnItems");
                });

            modelBuilder.Entity("App.Models.Customer", b =>
                {
                    b.Navigation("CustomerAddresses");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("App.Models.Invoice", b =>
                {
                    b.Navigation("InvoiceShipmentItems");
                });

            modelBuilder.Entity("App.Models.Order", b =>
                {
                    b.Navigation("CreditNotes");

                    b.Navigation("Invoices");

                    b.Navigation("OrderItems");

                    b.Navigation("Shipments");
                });

            modelBuilder.Entity("App.Models.OrderItem", b =>
                {
                    b.Navigation("CreditNoteReturnItems");

                    b.Navigation("ShipmentItems");
                });

            modelBuilder.Entity("App.Models.Product", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("App.Models.Shipment", b =>
                {
                    b.Navigation("ShipmentItems");
                });

            modelBuilder.Entity("App.Models.ShipmentItem", b =>
                {
                    b.Navigation("CreditNoteReturnItems");
                });
#pragma warning restore 612, 618
        }
    }
}
