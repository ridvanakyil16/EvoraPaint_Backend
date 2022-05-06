using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {

        IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Order entity)
        {
            _orderDal.Add(entity);

            var result = _orderDal.GetOrderDetail(x => x.Id == entity.Id);


            string to = "performancemessage@gmail.com";
            string from = "performancemessage@gmail.com";
            string password = "1E2R3T4Y";

            MailMessage message = new MailMessage(from, to);
            message.Subject = "Sipariş";
            message.IsBodyHtml = true;
            message.Body = @$";Sipariş : 
            
            <html>
                <body>
                    <form style='width: 300px; height: 400px; border-radius: 4px; border: 1px solid rgb(167, 166, 166); overflow: hidden;'>
                        <div style='width:100%; height:100px; background-color: #086E7D; display: flex; justify-content: center; align-items: center; color: #fff; font-size: 20px;'>
                            Siparişiniz Var
                        </div>
                        <div style='padding: 10px;'>
                            <p>Sipariş Eden : {result.SenderMail}</p>
                            <p>Sipariş Id'si : {result.Id}</p>
                            <p>Kategori : {result.CategoryTRName}</p>
                            <p>Marka : {result.BrandName}</p>
                            <p>Renk : {result.ColorName}</p>
                            <p>Ürün Adı : {result.Name}</p>
                            <p>Adet : {entity.UnitAmount}</p>
                        </div>
                    </form>
                </body>
            </html>

            ";

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(from, password);
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Port = 587;
            client.UseDefaultCredentials = false;

            client.Send(message);

            return new SuccessResult(Messages.OrderAdded);
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(Order entity)
        {
            _orderDal.Delete(entity);
            return new SuccessResult(Messages.OrderDeleted);
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Order entity)
        {
            _orderDal.Update(entity);
            return new SuccessResult(Messages.OrderUpdated);
        }


        //Gereksizler start
        [CacheAspect]
        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(), Messages.OrdersListed);
        }
        [CacheAspect]
        public IDataResult<Order> GetById(int id)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(p => p.Id == id), Messages.OrderListed);
        }
        //Gereksizler end


        [CacheAspect]
        public IDataResult<List<OrderDetailsDto>> GetAllOrderDetail()
        {
            return new SuccessDataResult<List<OrderDetailsDto>>(_orderDal.GetAllOrderDetail(), Messages.OrdersListed);
        }
        [CacheAspect]
        public IDataResult<OrderDetailsDto> GetOrderDetail(int orderId)
        {
            return new SuccessDataResult<OrderDetailsDto>(_orderDal.GetOrderDetail(x => x.Id == orderId), Messages.OrderListed);
        }
    }
}
