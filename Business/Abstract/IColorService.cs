﻿using Core.Utilities.Results;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(Color entity);
        IResult Update(Color entity);
        IResult Delete(Color entity);
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int id);
    }
}
