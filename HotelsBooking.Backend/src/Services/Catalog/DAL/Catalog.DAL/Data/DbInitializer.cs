namespace Catalog.DAL.Data
{
    public class DbInitializer
    {
        public static void Initializer(CatalogDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
