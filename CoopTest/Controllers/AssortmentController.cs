using CoopTest.Interfaces;
using CoopTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoopTest.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AssortmentController : ControllerBase
  {
    private readonly IAssortmentInterface _repo;

    public AssortmentController(IAssortmentInterface repo)
    {
      _repo = repo;
    }

    [HttpPost("/AddAssortment")]
    public async Task<ActionResult> AddAssortment(Assortment assortment)
    {
      var result = await _repo.AddAssortment(assortment);
      return Ok(result);
    }

    [HttpGet("/GetAssortments")]
    public List<Assortment> GetAssortments()
    {
      var result = _repo.GetAssortments();
        return result;
    }
  }
}
