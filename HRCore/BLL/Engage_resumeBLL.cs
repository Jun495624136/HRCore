using System;
using System.Collections.Generic;
using System.Text;
using IDAO;
using IBLL;
using System.Threading.Tasks;
using Model;

namespace BLL
{
   public class Engage_resumeBLL:IEngage_resumeBLL
    {
        private readonly IEngage_resumeDAO sdao;
        public Engage_resumeBLL(IEngage_resumeDAO sdao)
        {
            this.sdao = sdao;
        }

        public Task<int> Add(Engage_resume_Model cfk)
        {
            return sdao.Add(cfk);
        }

        public Engage_resume_Model CfSelectBy(int id)
        {
            return sdao.CfSelectBy(id);
        }

        public List<Engage_resume_Model> FenYe(FenYeModel fen)
        {
            return sdao.FenYe(fen);
        }

        public Task<int> ResumeUpdate(Engage_resume_Model erm)
        {
            return sdao.ResumeUpdate(erm);
        }

        public Task<int> ResumeUpdate2(Engage_resume_Model erm)
        {
            return sdao.ResumeUpdate2(erm);
        }

        public List<Engage_resume_Model> ResumeUpSelect()
        {
            return sdao.ResumeUpSelect();
        }

        public Task<Engage_resume_Model> SelectResume(int id)
        {
            return sdao.SelectResume(id);
        }
    }
}
