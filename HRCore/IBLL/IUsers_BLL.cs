
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public interface IUsers_BLL
    {
        List<Users_Model> Login();
    }
}
