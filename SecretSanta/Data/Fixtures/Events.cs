using System.Linq;
using SecretSanta.Models;

namespace SecretSanta.Data.Fixtures
{
    public static class Events
    {
        public static void Load(SecretSantaContext context)
        {
            if (context.Events.Any())
            {
                return; // Events have been loaded
            }

            var events = new[]
            {
                new Event {Name = "Soccer"},
                new Event {Name = "Swimming"},
                new Event {Name = "Golf"}
            };

            foreach (Event e in events)
            {
                context.Events.Add(e);
            }

            context.SaveChanges();
        }
    }
}
