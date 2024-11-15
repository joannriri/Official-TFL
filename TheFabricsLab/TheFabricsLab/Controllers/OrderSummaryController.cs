using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TheFabricsLab.Areas.Identity.Data;
using TheFabricsLab.Models.ViewModel;

namespace TheFabricsLab.Controllers
{
    public class OrderSummaryController : Controller
    {
        private readonly AppDbContext _context;

        public OrderSummaryController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Variants)
                .Where(o => o.OrderID == orderId)
                .FirstOrDefaultAsync();

            if (order == null)
            {
                return NotFound();
            }

            var orderSummary = new OrderSummaryViewModel
            {
                OrderID = order.OrderID,
                OrderDate = order.OrderDate,
                OrderTotal = order.OrderTotal,
                Email = order.Email,
                PhoneNumber = order.PhoneNumber,
                DeliveryMethod = order.DeliveryMethod,
                ShippingAddress = $"{order.FirstName} {order.LastName}, {order.ShippingAddress}, {order.City}, {order.PostalCode}, {order.Country}",
                ShippingFee = order.ShippingFee,
                OrderDetails = order.OrderDetails.Select(od => new OrderItemViewModel
                {
                    ProductID = od.ProductID,
                    ProductName = od.Product.ProductName,
                    ImageFile = od.Product.ImageFile,
                    Color = od.Variants.Color,
                    Quantity = od.Quantity,
                    UnitPrice = od.UnitPrice,
                    LineTotal = od.LineTotal
                }).ToList()
            };

            return View(orderSummary);
        }

    }
}
