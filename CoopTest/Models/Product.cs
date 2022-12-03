using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoopTest.Models
{
  public class Product
  {
    [JsonPropertyName("Name"), Required, MaxLength(200)]
    public string Name { get; set; }

    [JsonPropertyName("EANCode"), Required, MaxLength(20)]
    public string EANCode { get; set; }
  }

  public class ProductAssortment
  {
    [JsonPropertyName("ProductId"), Required]
    public int ProductId { get; set; }

    [JsonPropertyName("AssortmentId"), Required]
    public int AssortmentId { get; set; }
  }
}
