using SoruTest.Business.Abstract;
using SoruTest.Core.Utilities.Result;
using SoruTest.DataAccess.Abstract;
using SoruTest.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoruTest.Business.Concrete
{
    public class QuestionManager : IQuestionService
    {
        IQuestionDal _questionDal;
        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }

        public IResult Add(Question question)
        {
            _questionDal.Add(question);
            return new SuccessResult();
        }

        public IResult Delete(Question question)
        {
            _questionDal.Delete(question);
            return new SuccessResult();
        }

        public List<Question> GetAll()
        {
            return _questionDal.GetAll();
        }

        public IDataResult<Question> GetById(int id)
        {
            return new SuccessDataResult<Question>(_questionDal.Get(e => e.Id == id));
        }

        public IResult Update(Question question)
        {
            _questionDal.Update(question);
            return new SuccessResult();
        }
    }
}
