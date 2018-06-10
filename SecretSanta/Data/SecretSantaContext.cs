using SecretSanta.Models;
using Microsoft.EntityFrameworkCore;

namespace SecretSanta.Data
{
	public class SecretSantaContext : DbContext
	{
		public DbSet<Event> Events { get; set; }

		public SecretSantaContext(DbContextOptions<SecretSantaContext> options) : base(options)
		{
			this.Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseMySql(@"Server=localhost;database=secret_santa_dev;uid=root;pwd=password;port=13306;");
	}
}