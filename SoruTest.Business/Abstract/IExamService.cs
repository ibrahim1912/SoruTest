using SoruTest.Core.Utilities.Result;
using SoruTest.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoruTest.Business.Abstract
{
    public interface IExamService
    {
        IResult Add(Exam exam);
        IResult Update(Exam exam);
        IResult Delete(Exam exam);
        List<Exam> GetAll();
        Exam GetById(int id);
        
    }
}
