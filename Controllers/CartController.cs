using KassaPro.Data;
using KassaPro.Data.Entities;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace KassaPro.Controllers.Api.V1
{
    [ApiController]
    [Route("api/v1/cart")]
    public class CartController : ControllerBase
    {
        private readonly PosContext _context;

        public CartController(PosContext context)
        {
            _context = context;
        }

        // GET: api/v1/cart/add-to-cart/5
        [HttpGet("add-to-cart/{id}")]
        public async Task<IActionResult> AddToCart(ulong id)
        {
            // var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            // var orderDetail = await _context.OrderDetails.FirstOrDefaultAsync(o => o.ProductId == id);

            return Ok(new
            {
                success = true,
                message = "You Product", // translate qo‘shmoqchi bo‘lsangiz i18n kutubxona kerak
                // product,
                // order_details = orderDetail
            });
        }

        // DELETE: api/v1/cart/remove-cart/5
        [HttpDelete("remove-cart/{id}")]
        public async Task<IActionResult> RemoveCart(long id)
        {
            // var pos = await _context.Poss.FindAsync(id);
            // if (pos == null)
            // {
            //     return NotFound(new { success = false, message = "Cart item not found" });
            // }

            // _context.Poss.Remove(pos);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                message = "Cart item removed successfully"
            });
        }
    }
}
