using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IDAO;
using IBLL;
namespace BLL
{
    public  class Salary_standardModeBLL3:Salary_standardModelIBLL3
    {
        private readonly Salary_standardModelIDAO3 coreDbContext;
        public Salary_standardModeBLL3(Salary_standardModelIDAO3 coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }

        public List<Salary_standard_Model> Select()
        {
            return coreDbContext.Select();
        }
    }
}
