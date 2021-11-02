using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaxCalculator.Models;
using TaxCalculator.Invokers;

namespace TaxCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly TaxCalculatorContext _context;

        public OrdersController(TaxCalculatorContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public ActionResult<List<OrderDTO>> GetOrders()
        {
            var aux = _context.Orders.Include(x => x.Items).ToList();
            return aux.Select(x => OrderToDTO(x)).ToList();
        }

        // POST api/<OrdersController>
        [HttpPost]
        public ActionResult<OrderDTO> Process(OrderDTO order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            VATCalculator VATCalculator = new VATCalculator();
            VATCalculator.Calculate(order);
            return order;

        }
        private static OrderDTO OrderToDTO(Order order)
        {

            return new OrderDTO(order.Id, order.Items.Select(x=>ItemToDTO(x)).ToList(),order.Total);
        }
        private static ItemDTO ItemToDTO(Item Item)
        {
            return new ItemDTO(Item.Id, Item.PricePerUnit, Item.Units, Item.Type.Id);
        }
    }
}
