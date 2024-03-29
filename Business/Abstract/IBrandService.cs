﻿using Core.Utilities.Results;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IResult Add(Brand entity);
        IResult Update(Brand entity);
        IResult Delete(Brand entity);
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetById(int id);
    }
}
