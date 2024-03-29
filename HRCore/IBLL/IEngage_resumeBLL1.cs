﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IEngage_resumeBLL1
    {
        Task<int> Add(Engage_resume_Model cfk);
        List<Engage_resume_Model> FenYe(FenYeModel fen);
        List<Engage_resume_Model> ResumeUpSelect();
        Task<int> ResumeUpdate(Engage_resume_Model erm);
        Task<Engage_resume_Model> SelectResume(int id);
        Engage_resume_Model CfSelectBy(int id);
        Task<int> ResumeUpdate2(Engage_resume_Model erm);
    }
}
