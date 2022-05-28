namespace Identity.Dal.Data
{
    public class DbInitializer
    {
        public static void Initialize(IdentityDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
