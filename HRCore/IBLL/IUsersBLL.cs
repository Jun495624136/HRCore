using Model;
using System;
using System.Collections.Generic;

namespace IBLL
{
    public interface IUsersBLL
    {
        List<Users_Model> Login();
        List<Users_Model> SeledctUser(int id);
    }
}
