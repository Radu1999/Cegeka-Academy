using CarDealership.Data.Models;
using Microsoft.EntityFrameworkCore;
using WebCarDealership;

namespace CarDealership.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly DealershipDbContext context;
        public Repository(DealershipDbContext context)
        {
            this.context = context;
        }

        public async Task<CarOffer> GetCarOfferById(int id)
        {
            return await context.CarOffers.FirstOrDefaultAsync(offer => offer.Id == id);
        }

        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
        }

        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }

    }
}
