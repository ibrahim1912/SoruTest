using SoruTest.Core.DataAccess;
using SoruTest.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoruTest.DataAccess.Abstract
{
    public interface IUserDal: IEntityRepository<User>
    {
    }
}
