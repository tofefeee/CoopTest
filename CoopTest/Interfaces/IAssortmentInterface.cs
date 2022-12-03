using CoopTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoopTest.Interfaces
{
  public interface IAssortmentInterface
  {
    Task<string> AddAssortment(Assortment assortment);

    List<Assortment> GetAssortments();
  }
}
