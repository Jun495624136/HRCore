using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IEngage_major_releaseBLL
    {
        Task<int> Add(Engage_major_release_Model ad);
        List<Engage_major_release_Model> FenYe(FenYeModel fen);
        Task<int> Del(int id);
        Task<Engage_major_release_Model> SelectById(int id);
        Task<int> Update(Engage_major_release_Model ad);
    }
}
