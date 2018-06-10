using System.Linq;
using SecretSanta.Models;

namespace SecretSanta.Data
{
	public static class SeedEvents
	{
		public static void Seed(SecretSantaContext context)
		{
			// Look for any events
			if (context.Events.Any()) {
				return; // DB has been seeded
			}

			var events = new[]
			{
				new Event {Name = "Soccer"},
				new Event {Name = "Swimming"},
				new Event {Name = "Golf"}
			};

			foreach (Event s in events) {
				context.Events.Add(s);
			}

			context.SaveChanges();
		}
	}
}