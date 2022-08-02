using Microsoft.EntityFrameworkCore;

namespace producerAPI.Models
{
   public class ExampleContext : DbContext
   {
      public ExampleContext(DbContextOptions options) : base(options)
      {
      }
      public ExampleContext()
      {

      }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         optionsBuilder.UseSqlServer("Initial Catalog=master; Data Source=localhost,1450;Persist Security Info=True;User ID=sa;Password=2Secure*Password2");
      }
   }
}