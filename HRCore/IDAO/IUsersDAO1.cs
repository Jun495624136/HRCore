using System;
using System.Collections.Generic;
using Model;

namespace IDAO
{
    public interface IUsersDAO1
    {
        List<Users_Model> Login();
        List<Users_Model> SeledctUser(int id);
    }
}
