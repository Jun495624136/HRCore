using System;
using System.Collections.Generic;
using Model;

namespace IDAO
{
    public interface IUsersDAO
    {
        List<Users_Model> Login();
        List<Users_Model> SeledctUser(int id);
    }
}
