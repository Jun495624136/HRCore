using System;
using System.Collections.Generic;
using System.Text;
using IDAO;
using IBLL;
using Model;
namespace BLL
{
    public class config_file_third_kindBLL:config_file_third_kindIBLL
    {
        private readonly config_file_third_kindIDAO coreDbContext;
        public config_file_third_kindBLL(config_file_third_kindIDAO coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }

        public List<Config_file_third_kind_Model> SJselect()
        {
            return coreDbContext.SJselect();
        }
    }
}
