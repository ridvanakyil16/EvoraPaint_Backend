using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Net.Mail;

namespace Business.Concrete
{
    public class MailManager : IMailService
    {

        IMailDal _mailDal;

        public MailManager(IMailDal mailDal)
        {
            _mailDal = mailDal;
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Mail entity)
        {
            _mailDal.Add(entity);


            string to = "performancemessage@gmail.com";
            string from = "performancemessage@gmail.com";
            string password = "1E2R3T4Y";

            MailMessage message = new MailMessage(from, to);
            message.Subject = "Mesaj";
            message.IsBodyHtml = true;
            message.Body = @$";Mesaj : 
            
            <html>
                 <body>
                    <form style='width: 450px; height: auto; border-radius: 4px; border: 1px solid rgb(167, 166, 166); overflow: hidden;'>
                        <div style='width:100%; height:100px; text-align:center; background-color: #030303; display: flex; justify-content: center; align-items: center; color: #fff; font-size: 20px; padding:20px 40px'>
                            <img style='width:370px;' src='https://cdn-bejhi.nitrocdn.com/XAsvAcLlNeUALTJLIdNKVsdpmwHaSwKT/assets/static/optimized/wp-content/uploads/2020/09/5e33a8859e004b4e27d98bd2d55fd668.evora-logo-rb.png'>
                        </div>

                        <div style='padding: 10px; text-align: center;'>
 
                             <p> Ad : { entity.FirstName}</p>
                             <p> Soyad : { entity.LastName}</p>
                             <hr>
                             <p> Email : { entity.EmailAddress}</p>
                             <p> Telofon : { entity.Phone}</p>
                             <hr>
                             <p> Mesaj : { entity.Message}</p>

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
            return new SuccessResult(Messages.MailAdded);
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(Mail entity)
        {
            _mailDal.Delete(entity);
            return new SuccessResult(Messages.MailDeleted);
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Mail entity)
        {
            _mailDal.Update(entity);
            return new SuccessResult(Messages.MailUpdated);
        }
        [CacheAspect]
        public IDataResult<List<Mail>> GetAll()
        {
            return new SuccessDataResult<List<Mail>>(_mailDal.GetAll(), Messages.MailsListed);
        }
        [CacheAspect]
        public IDataResult<Mail> GetById(int id)
        {
            return new SuccessDataResult<Mail>(_mailDal.Get(p => p.Id == id), Messages.MailListed);
        }
    }
}
