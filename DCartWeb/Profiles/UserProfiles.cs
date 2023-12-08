using AutoMapper;
using DCartWeb.Models.Carts;
using DCartWeb.Models.Orders;

namespace DCartWeb.Profiles
{
    public class UserProfiles : Profile
    {
        /// <summary>
        /// Used to define what automapper is supposed to map
        /// </summary>
        public UserProfiles()
        {
         
            // Goes from source => destination

            CreateMap<CartItem, OrderItem>().ForMember(x => x.Id,opt =>
            {
                opt.Ignore();
            });
            CreateMap<Cart,Order>();
        }
    }
}
