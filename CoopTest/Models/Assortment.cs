using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoopTest.Models
{
  public class Assortment
  {
    [JsonPropertyName("Name"), Required, MaxLength(100)]
    public string Name { get; set; }


    [JsonPropertyName("ActiveFrom"), Required]
    public DateTime ActiveFrom { get; set; }


    [JsonPropertyName("ActiveTo")]
    public DateTime ActiveTo { get; set; }
  }
}
