using System;
using System.Collections.Generic;
using System.Text;
using IDAO;
using IBLL;
using System.Threading.Tasks;
using Model;

namespace BLL
{
   public class Engage_interviewBLL1:IEngage_interviewBLL1
    {
        private readonly IEngage_interviewDAO1 sdao;

        public Engage_interviewBLL1(IEngage_interviewDAO1 sdao)
        {
            this.sdao = sdao;
        }

        public Task<int> Add(Engage_interview_Model eim)
        {
            return sdao.Add(eim);
        }

        public Engage_interview_Model CfSelectBy(int id)
        {
            return sdao.CfSelectBy(id);
        }

        public List<Engage_interview_Model> FenYe(FenYeModel fen)
        {
            return sdao.FenYe(fen);
        }

        public Task<int> InterviewUpdate(Engage_interview_Model eim)
        {
            return sdao.InterviewUpdate(eim);
        }

        public List<Engage_interview_Model> Selectinterview()
        {
            return sdao.Selectinterview();
        }

        public Task<int> Update(Engage_resume_Model erm)
        {
            return sdao.Update(erm);
        }
    }
}
