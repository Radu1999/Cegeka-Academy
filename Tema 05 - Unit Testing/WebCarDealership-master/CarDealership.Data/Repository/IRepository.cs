using CarDealership.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Repository
{
    public interface IRepository
    {
        Task<CarOffer> GetCarOfferById(int id);
        void AddOrder(Order order);
        Task<int> SaveChanges();
    }
}
