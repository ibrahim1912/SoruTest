using SoruTest.Business.Abstract;
using SoruTest.Core.Utilities.Result;
using SoruTest.DataAccess.Abstract;
using SoruTest.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoruTest.Business.Concrete
{
    public class CorrectAnswerManager : ICorrectAnswerService
    {
        ICorrectAnswerDal _correctDal;
        public CorrectAnswerManager(ICorrectAnswerDal correctDal)
        {
            _correctDal = correctDal;
        }
        public IResult Add(CorrectAnswer correctAnswer)
        {
            _correctDal.Add(correctAnswer);
            return new SuccessResult();
        }

        public IResult Delete(CorrectAnswer correctAnswer)
        {
            _correctDal.Delete(correctAnswer);
            return new SuccessResult();
        }

        public List<CorrectAnswer> GetAll()
        {
            return _correctDal.GetAll();
        }

        public IDataResult<CorrectAnswer> GetById(int id)
        {
            return new SuccessDataResult<CorrectAnswer>(_correctDal.Get(e => e.Id == id));
        }

        public IResult Update(CorrectAnswer correctAnswer)
        {
            _correctDal.Update(correctAnswer);
            return new SuccessResult();
        }
    }
}
