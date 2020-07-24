using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Threading.Tasks;

namespace IDAO
{
    public interface IEngage_major_releaseDAO
    {
        //添加
        Task<int> Add(Engage_major_release_Model ad);
        //分页查询
        List<Engage_major_release_Model> FenYe(FenYeModel fen);
        //删除
        Task<int> Del(int id);
        //修改传值
        Task<Engage_major_release_Model> SelectById(int id);
        Task<int> Update(Engage_major_release_Model ad);
    }
}
