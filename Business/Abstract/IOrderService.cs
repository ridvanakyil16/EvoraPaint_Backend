using Core.Utilities.Results;
using Entites.Concrete;
using Entites.DTOs;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IResult Add(Order entity);
        IResult Update(Order entity);
        IResult Delete(Order entity);
        IDataResult<List<Order>> GetAll();
        IDataResult<Order> GetById(int id);
        public IDataResult<List<OrderDetailsDto>> GetAllOrderDetail();
        public IDataResult<OrderDetailsDto> GetOrderDetail(int orderId);
    }
}
