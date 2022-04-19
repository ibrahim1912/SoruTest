using SoruTest.Business.Abstract;
using SoruTest.Core.Utilities.Result;
using SoruTest.DataAccess.Abstract;
using SoruTest.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoruTest.Business.Concrete
{
    public class OptionManager : IOptionService
    {
        IOptionDal _optionDal;
        public OptionManager(IOptionDal optionDal)
        {
            _optionDal = optionDal;
        }
        public IResult Add(Option option)
        {
            _optionDal.Add(option);
            return new SuccessResult();
        }

        public IResult Delete(Option option)
        {
            _optionDal.Delete(option);
            return new SuccessResult();
        }

        public List<Option> GetAll()
        {
            return _optionDal.GetAll();
        }

        public IDataResult<Option> GetById(int id)
        {
            return new SuccessDataResult<Option>(_optionDal.Get(e => e.Id == id));
        }

        public IResult Update(Option option)
        {
            _optionDal.Update(option);
            return new SuccessResult();
        }
    }
}
