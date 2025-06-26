using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace schoolAPI.Models
{
  public class Student
  {
    [Key]
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [Required]
    [JsonPropertyName("fullName")]
    public required string FullName { get; set; }
    [ForeignKey("Course")]
    public Guid CourseId { get; set; }
    public Course? Course { get; set; }
  }
}