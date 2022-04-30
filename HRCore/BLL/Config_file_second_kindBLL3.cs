using System;
using System.Collections.Generic;
using System.Text;
using IDAO;
using IBLL;
using Model;
namespace BLL
{
    public class Config_file_second_kindBLL3:Config_file_second_kindIBLL3
    {
        private readonly Config_file_second_kindIDAO3 coreDbContext;
        public Config_file_second_kindBLL3(Config_file_second_kindIDAO3 coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }

        public List<Config_file_second_kind_Model> EJselect()
        {
            return coreDbContext.EJselect();
        }
    }
}
