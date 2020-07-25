using System;
using System.Collections.Generic;
using System.Text;
using Model;
using IBLL;
using IDAO;
namespace BLL
{
     public class config_major_kindBLL3:config_major_kindIBLL3
    {
        private readonly config_major_kindIDAO3 coreDbContext;
        public config_major_kindBLL3(config_major_kindIDAO3 coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }

        public List<Config_major_kind_Model> config_majorSelect()
        {
            return coreDbContext.config_majorSelect();
        }
    }
}
