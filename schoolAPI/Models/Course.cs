using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace schoolAPI.Models
{
  public class Course
  {
    [Key]
    [JsonPropertyName("id")]
    public Guid Id { get; set;  }
    [Required]
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    [JsonPropertyName("students")]
    public List<Student> Students { get; } = [];
  }
}