using System.Globalization;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers;

public class OrdersController(AppDbContext context) : Controller
{
    private readonly AppDbContext _context = context;

    public IActionResult Search()
    {
        var viewModel = new OrderSearchViewModel
        {
            StartDate = DateTime.UtcNow.Date,
            EndDate = DateTime.UtcNow.Date.AddDays(7)
        };
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Search(OrderSearchViewModel searchModel)
    {
        var query = _context.Orders
            .Include(o => o.Customer)
            .AsQueryable();

        if (searchModel.StartDate.HasValue)
        {
            query = query.Where(o => o.DateOrderPlaced >= searchModel.StartDate.Value.ToUniversalTime());
        }

        if (searchModel.EndDate.HasValue)
        {
            var endDate = searchModel.EndDate.Value.AddDays(1).ToUniversalTime();
            query = query.Where(o => o.DateOrderPlaced < endDate);
        }

        if (!string.IsNullOrWhiteSpace(searchModel.CustomerName))
        {
            var searchTerm = searchModel.CustomerName.Trim().ToLower(CultureInfo.InvariantCulture);
            query = query.Where(o =>
                o.Customer.FirstName.ToLower().Contains(searchTerm) ||
                o.Customer.LastName.ToLower().Contains(searchTerm));
        }

        searchModel.Results = await query
            .OrderBy(o => o.DateOrderPlaced)
            .ToListAsync();
        searchModel.SearchPerformed = true;

        return View(searchModel);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var order = await _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .Include(o => o.Shipments)
            .Include(o => o.Invoices)
            .Include(o => o.CreditNotes)
            .FirstOrDefaultAsync(o => o.OrderId == id);

        if (order is null)
        {
            return NotFound();
        }

        return View(order);
    }
}
