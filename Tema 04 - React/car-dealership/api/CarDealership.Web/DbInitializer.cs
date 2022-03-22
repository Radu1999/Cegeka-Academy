using CarDealership.Data;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Web
{
    public static class DbInitializer
    {
        public static void Initialize(DealershipDbContext context)
        {
            
            context.Database.Migrate();
        }
    }
}