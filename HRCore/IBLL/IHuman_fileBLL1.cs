using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IHuman_fileBLL1
    {
        Task<int> Add(Human_file_Model hfm);
        List<Human_file_Model> FenYe(FenYeModel fen);
        Task<Human_file_Model> SelectById(int id);
        Task<int> Update(Human_file_Model hfm);
        Task<int> FileUpdate(Human_file_Model erm);
        Task<int> Updatestatus(Human_file_Model erm);
        Task<int> deleteid(int id);
        List<Human_file_Model> SelectQuery();
        Task<int> Updatepictr(Human_file_Model erm);
        List<Human_file_Model> SelectQuery2();
    }
}
