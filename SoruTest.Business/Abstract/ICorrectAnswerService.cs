using SoruTest.Core.Utilities.Result;
using SoruTest.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoruTest.Business.Abstract
{
    public interface ICorrectAnswerService
    {
        IResult Add(CorrectAnswer correctAnswer);
        IResult Update(CorrectAnswer correctAnswer);
        IResult Delete(CorrectAnswer correctAnswer);
        List<CorrectAnswer> GetAll();
        IDataResult<CorrectAnswer> GetById(int id);
    }
}
