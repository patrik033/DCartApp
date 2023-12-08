using DCartWeb.Models.Orders;

namespace DCartWeb.Models.ViewModels
{
    public class AdminViewModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Order  Orders { get; set; } = new Order();
    }
}
