using System;
using System.Collections.Generic;
using System.Text;
using IBLL;
using Model;
using IDAO;
using System.Threading.Tasks;

namespace BLL
{
    public class Engage_major_releaseBLL1 : IEngage_major_releaseBLL1
    {
        private readonly IEngage_major_releaseDAO1 sdao;
        public Engage_major_releaseBLL1(IEngage_major_releaseDAO1 sdao)
        {
            this.sdao = sdao;
        }
        public Task<int> Add(Engage_major_release_Model ad)
        {
            return sdao.Add(ad);
        }

        public Task<int> Del(int id)
        {
            return sdao.Del(id);
        }

        public List<Engage_major_release_Model> FenYe(FenYeModel fen)
        {
            return sdao.FenYe(fen);
        }

        public Task<Engage_major_release_Model> SelectById(int id)
        {
            return sdao.SelectById(id);
        }

        public Task<int> Update(Engage_major_release_Model ad)
        {
            return sdao.Update(ad);
        }
    }
}
