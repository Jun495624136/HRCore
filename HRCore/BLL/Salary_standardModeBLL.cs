using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IDAO;
using IBLL;
namespace BLL
{
    public  class Salary_standardModeBLL:Salary_standardModelIBLL
    {
        private readonly Salary_standardModelIDAO coreDbContext;
        public Salary_standardModeBLL(Salary_standardModelIDAO coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }

        public List<Salary_standard_Model> Select()
        {
            return coreDbContext.Select();
        }
    }
}
