using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMailService
    {
        IResult Add(Mail entity);
        IResult Update(Mail entity);
        IResult Delete(Mail entity);
        IDataResult<List<Mail>> GetAll();
        IDataResult<Mail> GetById(int id);
    }
}
