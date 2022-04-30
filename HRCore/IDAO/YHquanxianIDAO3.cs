using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IDAO
{
    public interface YHquanxianIDAO3
    {
        List<YHquanxianModel> CX(int id);
        Task<int> add(YHquanxianModel a);
        Task<int> sc(int id);
    }
}
