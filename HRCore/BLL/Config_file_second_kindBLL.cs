using System;
using System.Collections.Generic;
using System.Text;
using IDAO;
using IBLL;
using Model;
namespace BLL
{
    public class Config_file_second_kindBLL:Config_file_second_kindIBLL
    {
        private readonly Config_file_second_kindIDAO coreDbContext;
        public Config_file_second_kindBLL(Config_file_second_kindIDAO coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }

        public List<Config_file_second_kind_Model> EJselect()
        {
            return coreDbContext.EJselect();
        }
    }
}
