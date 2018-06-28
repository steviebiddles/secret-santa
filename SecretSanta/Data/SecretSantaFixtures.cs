using SecretSanta.Data.Fixtures;

namespace SecretSanta.Data
{
	public static class SecretSantaFixtures
    {
        public static void Load(SecretSantaContext context)
        {
            context.Database.EnsureCreated();

            Events.Load(context);
        }
    }
}