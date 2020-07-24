using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using IDAO;
using Model;

namespace BLL
{
   public class Human_fileBLL:IHuman_fileBLL
    {
        private readonly IHuman_fileDAO sdao;
        public Human_fileBLL(IHuman_fileDAO sdao)
        {
            this.sdao = sdao;
        }

        public Task<int> Add(Human_file_Model hfm)
        {
            return sdao.Add(hfm);
        }

        public Task<int> deleteid(int id)
        {
            return sdao.deleteid(id);
        }

        public List<Human_file_Model> FenYe(FenYeModel fen)
        {
            return sdao.FenYe(fen);
        }

        public Task<int> FileUpdate(Human_file_Model erm)
        {
            return sdao.FileUpdate(erm);
        }

        public Task<Human_file_Model> SelectById(int id)
        {
            return sdao.SelectById(id);
        }

        public List<Human_file_Model> SelectQuery()
        {
            return sdao.SelectQuery();
        }

        public List<Human_file_Model> SelectQuery2()
        {
            return sdao.SelectQuery2();
        }

        public Task<int> Update(Human_file_Model hfm)
        {
            return sdao.Update(hfm);
        }

        public Task<int> Updatepictr(Human_file_Model erm)
        {
            return sdao.Updatepictr(erm);
        }

        public Task<int> Updatestatus(Human_file_Model erm)
        {
            return sdao.Updatestatus(erm);
        }
    }
}
