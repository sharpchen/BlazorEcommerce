using BlazorEcommerce.Client;
using BlazorEcommerce.Server.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    readonly ICartService _service;

    public CartController(ICartService service) => _service = service;

    [HttpPost("products")]
    public async Task<ActionResult<ServiceResponse<List<CartProductDTO>>>> GetCartProducts(List<CartItem> items)
    {
        var result = await _service.GetCartProducts(items);
        return Ok(result);
    }
}