using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers;

public class ShipmentsController(AppDbContext context) : Controller
{
    private readonly AppDbContext _context = context;
    
    public async Task<IActionResult> Index()
    {
        var shipmentList = await _context.Shipments
            .Include(static s => s.Order)
            .OrderByDescending(static s => s.DateShipped)
            .ToListAsync();
        return View(shipmentList);
    }
    
    public async Task<IActionResult> Details(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var shipment = await _context.Shipments
            .Include(static s => s.Order)
            .Include(static s => s.ShipmentItems)
            .ThenInclude(static si => si.OrderItem)
            .ThenInclude(static oi => oi.Product)
            .Include(static s => s.ShipmentItems)
            .ThenInclude(static si => si.CreditNoteReturnItems)
            .FirstOrDefaultAsync(s => s.ShipmentId == id);

        if (shipment is null)
        {
            return NotFound();
        }

        var viewModel = new ShipmentDetailsViewModel
        {
            Shipment = shipment,
            OrderDetails = shipment.Order,
            ShipmentItems = shipment.ShipmentItems
        };

        return View(viewModel);
    }
}