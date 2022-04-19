using SoruTest.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoruTest.Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        User GetById(int id);
        List<User> GetAll();
    }
}
