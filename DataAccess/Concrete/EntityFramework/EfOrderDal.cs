using Core.DataAccsess.EntityFramework;
using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, ReCapProjectContext>, IOrderDal
    {
        public List<OrderDetailsDto> GetAllOrderDetail(Expression<Func<Order, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from ord in filter is null ? context.Orders : context.Orders.Where(filter)
                             join pro in context.Products
                             on ord.ProductId equals pro.Id
                             join ct in context.Categories
                             on pro.CategoryId equals ct.Id
                             select new OrderDetailsDto
                             {
                                 Id = ord.Id,
                                 ProductId = pro.Id,
                                 Name = pro.Name,
                                 ProductImage = (from i in context.ProductImages where (pro.Id == i.ProductId) select i.ImagePath).FirstOrDefault(),
                                 SenderMail = ord.SenderMail,
                                 BrandName = pro.BrandName,
                                 ColorName = pro.ColorName,
                                 CategoryId = ct.Id,
                                 Description = pro.Description,
                                 UnitPrice = pro.UnitPrice,
                             };
                return result.ToList();
            }
        }
        public OrderDetailsDto GetOrderDetail(Expression<Func<Order, bool>> filter)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from ord in filter is null ? context.Orders : context.Orders.Where(filter)
                             join pro in context.Products
                             on ord.ProductId equals pro.Id
                             join ct in context.Categories
                             on pro.CategoryId equals ct.Id
                             select new OrderDetailsDto
                             {
                                 Id = ord.Id,
                                 ProductId = pro.Id,
                                 Name = pro.Name,
                                 ProductImage = (from i in context.ProductImages where (pro.Id == i.ProductId) select i.ImagePath).FirstOrDefault(),
                                 SenderMail = ord.SenderMail,
                                 BrandName = pro.BrandName,
                                 ColorName = pro.ColorName,
                                 CategoryId = ct.Id,
                                 Description = pro.Description,
                                 UnitPrice = pro.UnitPrice,
                             };
                return result.FirstOrDefault();
            }
        }

    }
}
