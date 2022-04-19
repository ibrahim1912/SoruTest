using SoruTest.Core.Utilities.Result;
using SoruTest.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoruTest.Business.Abstract
{
    public interface IQuestionService
    {
        IResult Add(Question question);
        IResult Update(Question question);
        IResult Delete(Question question);
        List<Question> GetAll();
        IDataResult<Question> GetById(int id);
    }
}
