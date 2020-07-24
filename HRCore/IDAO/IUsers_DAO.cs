using System.Collections.Generic;
using System.Threading.Tasks;
using Model;
namespace IDAO
{
    public interface IUsers_DAO
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        List<Users_Model> Login();
    }
}
