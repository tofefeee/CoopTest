using CoopTest.Interfaces;
using CoopTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoopTest.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ProductController : ControllerBase
  {
    private readonly IProductInterface _repo;

    public ProductController(IProductInterface repo)
    {
      _repo = repo;
    }

    [HttpPost("/AddProduct")]
    public async Task<ActionResult> AddProduct(Product product)
    {
      var result = await _repo.AddProduct(product);
      return Ok(result);
    }

    [HttpPut("/AddProductToAssortment")]
    public Task<string> AddProductToAssortment(ProductAssortment productAssortment)
    {
      return _repo.AddProductAssortment(productAssortment);
    }
  }
}
