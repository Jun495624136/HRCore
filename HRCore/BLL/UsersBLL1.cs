using System;
using System.Collections.Generic;
using IBLL;
using IDAO;
using Model;

namespace BLL
{
    public class UsersBLL1 : IUsersBLL1
    {
        private readonly IUsersDAO1 sdao;
        public UsersBLL1(IUsersDAO1 sdao)
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
