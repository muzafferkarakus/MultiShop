using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using MultiShop.Order.Persistance.Context;

namespace MultiShop.Order.Persistance.Repositories
{
    public class OrderingRepository : IOrderingRepository
    {
        private readonly OrderContext _context;

        public OrderingRepository(OrderContext context)
        {
            _context = context;
        }

        public List<Ordering> GetOrderingsByUserId(string id)
        {
            var values = _context.Orderings.Where(x => x.UserId == id).ToList();
            return values;
        }
    }
}
