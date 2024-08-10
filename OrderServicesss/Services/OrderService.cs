using OrderServicesss.Models;

namespace OrderServicesss.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderContext _context;
        public OrderService(OrderContext context)
        {
            _context = context;
        }
        public bool CreateOrder(Order order)
        {
            try
            {
                _context.Orderss.Add(order);
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Order> GetAllOrders()
        {
            try
            {
                var res = _context.Orderss.ToList();
                if (res != null)
                {
                    return res;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }


        public List<Order> GetOrderByMail(string email)
        {
            try
            {
                var res = _context.Orderss.Where(r => r.RestaurantEmail == email).ToList();
                if (res != null)
                {
                    return res;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

    }
}
