using Microsoft.EntityFrameworkCore;

namespace schoolAPI.Models
{
  public class SchoolContext : DbContext
  {
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Course>()
        .HasMany(c => c.Students)
        .WithOne(s => s.Course)
        .HasForeignKey(s => s.CourseId)
        .OnDelete(DeleteBehavior.Cascade);
    }
  }
}