using SoruTest.Business.Abstract;
using SoruTest.Core.Utilities.Result;
using SoruTest.DataAccess.Abstract;
using SoruTest.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoruTest.Business.Concrete
{
    public class ExamManager : IExamService
    {
        IExamDal _examDal;
        public ExamManager(IExamDal examDal)
        {
            _examDal = examDal;
        }
        public IResult Add(Exam exam)
        {
            _examDal.Add(exam);
            return new SuccessResult();
        }

        public IResult Delete(Exam exam)
        {
            _examDal.Delete(exam);
            return new SuccessResult();
        }

        public List<Exam> GetAll()
        {
            return _examDal.GetAll();
        }

        public Exam GetById(int id)
        {
            return _examDal.Get(e => e.Id == id);
        }

        public IResult Update(Exam exam)
        {
            _examDal.Update(exam);
            return new SuccessResult();
        }
    }
}
