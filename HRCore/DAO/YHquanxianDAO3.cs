using System;
using System.Collections.Generic;
using System.Text;
using Model;
using EFEntity;
using IDAO;
using System.Threading.Tasks;
using System.Linq;

namespace DAO
{
    public class YHquanxianDAO3:YHquanxianIDAO3
    {
        private readonly HR_DBContext coreDbContext;
        public YHquanxianDAO3(HR_DBContext coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }

        public async Task<int> add(YHquanxianModel a)
        {
            YHquanxian b = new YHquanxian
            {
                 JueSe_id=a.JueSe_id,
                  YHid=a.YHid
            };
            coreDbContext.YHquanxians.Add(b);
            return await coreDbContext.SaveChangesAsync();
        }

        public List<YHquanxianModel> CX(int id)
        {
            List<YHquanxian> aa = coreDbContext.YHquanxians.ToList();
            List<YHquanxianModel> bb = new List<YHquanxianModel>();
            foreach (YHquanxian item in aa)
            {
                if (item.JueSe_id==id) 
                {
                    YHquanxianModel ff = new YHquanxianModel()
                    {
                        id = item.id,
                        JueSe_id = item.JueSe_id,
                        YHid = item.YHid
                    };
                    bb.Add(ff);
                }
            }
            return  bb;
        }

        public Task<int> sc(int id)
        {
            throw new NotImplementedException();
        }
    }
}
