using IBLL;
using IDAO;
using Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class YHquanxianBLL:YHquanxianIBLL
    {
        private readonly YHquanxianIDAO coreDbContext;
        public YHquanxianBLL(YHquanxianIDAO coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }

        public Task<int> add(YHquanxianModel a)
        {
            return coreDbContext.add(a);
        }

        public List<YHquanxianModel> CX(int id)
        {
            return coreDbContext.CX(id);
        }

        public Task<int> sc(int id)
        {
            throw new NotImplementedException();
        }
    }
}
