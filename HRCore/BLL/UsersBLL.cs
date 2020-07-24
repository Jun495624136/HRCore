using System;
using System.Collections.Generic;
using IBLL;
using IDAO;
using Model;

namespace BLL
{
    public class UsersBLL : IUsersBLL
    {
        private readonly IUsersDAO sdao;
        public UsersBLL(IUsersDAO sdao)
        {
            this.sdao = sdao;
        }
        public List<Users_Model> Login()
        {
            return sdao.Login();
        }

        public List<Users_Model> SeledctUser(int id)
        {
            return sdao.SeledctUser(id);
        }
    }
}
