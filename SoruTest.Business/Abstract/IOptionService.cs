using SoruTest.Core.Utilities.Result;
using SoruTest.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoruTest.Business.Abstract
{
    public interface IOptionService
    {
        IResult Add(Option option);
        IResult Update(Option option);
        IResult Delete(Option option);
        List<Option> GetAll();
        IDataResult<Option> GetById(int id);
    }
}
