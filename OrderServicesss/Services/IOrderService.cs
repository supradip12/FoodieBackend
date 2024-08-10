using OrderServicesss.Models;

namespace OrderServicesss.Services
{
    public interface IOrderService
    {
        bool CreateOrder(Order order);
        List<Order> GetAllOrders();
        List<Order> GetOrderByMail(string email);
    }
}