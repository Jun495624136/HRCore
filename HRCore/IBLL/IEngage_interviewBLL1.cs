﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IEngage_interviewBLL1
    {
        Task<int> Add(Engage_interview_Model eim);
        List<Engage_interview_Model> FenYe(FenYeModel fen);
        List<Engage_interview_Model> Selectinterview();
        Engage_interview_Model CfSelectBy(int id);
        Task<int> InterviewUpdate(Engage_interview_Model eim);
        Task<int> Update(Engage_resume_Model sd);
    }
}
