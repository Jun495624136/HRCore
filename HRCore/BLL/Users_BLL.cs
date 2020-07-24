using System;
using IDAO;
using IBLL;
using System.Threading.Tasks;
using System.Collections.Generic;
using Model;
namespace BLL
{
    public class Users_BLL : IUsers_BLL
    {
        private readonly IUsers_DAO dAO;
        public Users_BLL(IUsers_DAO dAO)
        {
            this.dAO = dAO;
        }
        public List<Users_Model> Login()
        {
            return dAO.Login();
        }
    }
}
