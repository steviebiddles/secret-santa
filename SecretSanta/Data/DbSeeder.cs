namespace SecretSanta.Data
{
	public static class DbSeeder
    {
        public static void Seed(SecretSantaContext context)
        {
            context.Database.EnsureCreated();

			SeedEvents.Seed(context);
        }
    }
}