using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAO
{
    public interface IConfig_file_first_kindDAO
    {
        List<Config_file_first_kind_Model> SelectFirst();
    }
}
