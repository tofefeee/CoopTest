using CoopTest.Models;
using System.Threading.Tasks;

namespace CoopTest.Interfaces
{
  public interface IProductInterface
  {
    Task<string> AddProduct(Product product);

    Task<string> AddProductAssortment(ProductAssortment productAssortment);
  }
}
