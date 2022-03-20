using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCarDealership;

namespace CarDealership.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DealershipDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
