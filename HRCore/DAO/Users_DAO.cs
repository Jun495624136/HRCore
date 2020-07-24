using System;
using Model;
using IDAO;
using EFEntity;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace DAO
{
    public class Users_DAO : IUsers_DAO
    {
        private readonly HR_DBContext dBContext;
        public Users_DAO(HR_DBContext dBContext) 
        {
            this.dBContext = dBContext;
        }
        public List<Users_Model> Login()
        {
            List<Users> list = dBContext.User.ToList();
            List<Users_Model> list2 = new List<Users_Model>();
            foreach (var item in list)
            {
                Users_Model users_ = new Users_Model()
                {
                    U_id = item.U_id,
                    U_name = item.U_name,
                    U_password = item.U_password,
                    U_true_name = item.U_true_name,
                    JueSe_name = item.JueSe_name
                };
            list2.Add(users_);
            }
            return list2;
            //var result = await Task.Run(()=> 
            //{
            //    foreach (var item in list)
            //    {
            //        Users_Model users_ = new Users_Model() 
            //        {
            //            U_id=item.U_id,
            //            U_name = item.U_name,
            //            U_password = item.U_password,
            //            U_true_name = item.U_true_name,
            //            JueSe_name = item.JueSe_name
            //        };
            //        list2.Add(users_);
            //    }
            //    return list2;
            //});
            //return result;
        }
    }
}
