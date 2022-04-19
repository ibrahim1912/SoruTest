using SoruTest.Core.DataAccess.EntityFramework;
using SoruTest.DataAccess.Abstract;
using SoruTest.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoruTest.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal: EfEntityRepositoryBase<User, SoruTestContext>, IUserDal
    {
    }
}
