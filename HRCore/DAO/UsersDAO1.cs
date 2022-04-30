using System;
using Model;
using IDAO;
using System.Collections.Generic;
using EFEntity;

using System.Linq;
using System.Threading.Tasks;

namespace DAO
{
    public class UsersDAO1 : IUsersDAO1
    {
        private readonly HR_DBContext hrDbContext;

        public UsersDAO1(HR_DBContext hrDbContext)
        {
            this.hrDbContext = hrDbContext;
        }
        public  List<Users_Model> Login()
        {
            var list = hrDbContext.User.ToList();
            List<Users_Model> list2 = new List<Users_Model>();
            
                foreach (var item in list)
                {
                    Users_Model cm = new Users_Model()
                    {
                     U_id=item.U_id,
                     U_name=item.U_name,
                     U_password=item.U_password,
                     U_true_name=item.U_true_name,
                     JueSe_name=item.JueSe_name
                    };
                    list2.Add(cm);
                }
                return list2;    
        }

        public List<Users_Model> SeledctUser(int id)
        {
            var list = hrDbContext.User.ToList();
            List<Users_Model> list2 = new List<Users_Model>();
            foreach (var item in list)
            {
                Users_Model ckm = new Users_Model()
                {
                    U_id = item.U_id,
                    U_name = item.U_name,
                    U_password = item.U_password,
                    U_true_name = item.U_true_name
                };
                list2.Add(ckm);
            }
            return list2;
        }
    }
}
