using Core.DataAccess;
using Entites.Concrete;
using Entites.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
        List<OrderDetailsDto> GetAllOrderDetail(Expression<Func<Order, bool>> filter = null);
        OrderDetailsDto GetOrderDetail(Expression<Func<Order, bool>> filter);
    }
}
