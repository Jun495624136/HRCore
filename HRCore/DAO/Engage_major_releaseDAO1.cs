using System;
using System.Collections.Generic;
using System.Text;
using IDAO;
using Model;
using EFEntity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class Engage_major_releaseDAO1 : IEngage_major_releaseDAO1
    {
        private readonly HR_DBContext hR_DBContext;
        public Engage_major_releaseDAO1(HR_DBContext hR_DBContext)
        {
            this.hR_DBContext = hR_DBContext;
        }

        public Task<int> Add(Engage_major_release_Model ad)
        {
            Engage_major_release emr = new Engage_major_release()
            {
                Mre_id = ad.Mre_id,
                First_kind_id = ad.First_kind_id,
                First_kind_name = ad.First_kind_name,
                Second_kind_id = ad.Second_kind_id,
                Second_kind_name = ad.Second_kind_name,
                Third_kind_id = ad.Third_kind_id,
                Third_kind_name = ad.Third_kind_name,
                Engage_type = ad.Engage_type,
                Major_kind_id = ad.Major_kind_id,
                Major_kind_name = ad.Major_kind_name,
                Major_id = ad.Major_id,
                Major_name = ad.Major_name,
                Human_amount = ad.Human_amount,
                Deadline = ad.Deadline,
                Register = ad.Register,
                Changer = ad.Changer,
                Change_time = ad.Change_time,
                Regist_time = ad.Regist_time,
                Major_describe = ad.Major_describe,
                Engage_required = ad.Engage_required
            };
            hR_DBContext.Engage_major_releases.Add(emr);
            return hR_DBContext.SaveChangesAsync();
        }


        public async Task<int> Del(int id)
        {
            Engage_major_release cmk = hR_DBContext.Engage_major_releases.Find(id);
            hR_DBContext.Engage_major_releases.Remove(cmk);
            return await hR_DBContext.SaveChangesAsync();
        }

        public List<Engage_major_release_Model> FenYe(FenYeModel fen)
        {
            List<Engage_major_release_Model> list = new List<Engage_major_release_Model>();
           
                SqlParameter[] ps = {
                    new SqlParameter(){ParameterName="@pageSize",Value=fen.PageSize},
                       new SqlParameter(){ParameterName="@keyName",Value=fen.KeyName},
                       new SqlParameter(){ParameterName="@tableName",Value=fen.TableName},
                       new SqlParameter(){ParameterName="@where",Value=fen.Where},
                       new SqlParameter(){ParameterName="@currentPage",Value=fen.CurrentPage},
                       new SqlParameter(){ParameterName="@rows",Direction=ParameterDirection.Output,SqlDbType=SqlDbType.Int},
                       new SqlParameter(){ParameterName="@pages",Direction=ParameterDirection.Output,SqlDbType=SqlDbType.Int}
                };
                var sql = hR_DBContext.Engage_major_releases.FromSqlRaw($@"exec dbo.FenYeWhere @pageSize,@keyName,@tableName,@where,@currentPage,@rows out,@pages out", ps).ToList();
                foreach (var ad in sql)
                {
                    Engage_major_release_Model sm = new Engage_major_release_Model()
                    {
                        Mre_id = ad.Mre_id,
                        First_kind_id = ad.First_kind_id,
                        First_kind_name = ad.First_kind_name,
                        Second_kind_id = ad.Second_kind_id,
                        Second_kind_name = ad.Second_kind_name,
                        Third_kind_id = ad.Third_kind_id,
                        Third_kind_name = ad.Third_kind_name,
                        Engage_type = ad.Engage_type,
                        Major_kind_id = ad.Major_kind_id,
                        Major_kind_name = ad.Major_kind_name,
                        Major_id = ad.Major_id,
                        Major_name = ad.Major_name,
                        Human_amount = ad.Human_amount,
                        Deadline = ad.Deadline,
                        Register = ad.Register,
                        Changer = ad.Changer,
                        Change_time = ad.Change_time,
                        Regist_time = ad.Regist_time,
                        Major_describe = ad.Major_describe,
                        Engage_required = ad.Engage_required
                    };
                    list.Add(sm);
                }
                fen.Pages = (int)ps[6].Value;
                fen.Rows = (int)ps[5].Value;
           
            return list;
        }

        public async Task<Engage_major_release_Model> SelectById(int id)
        {
            Engage_major_release ad = await hR_DBContext.Engage_major_releases.FindAsync(id);
            Engage_major_release_Model cffkm = new Engage_major_release_Model()
            {
                Mre_id = ad.Mre_id,
                First_kind_id = ad.First_kind_id,
                First_kind_name = ad.First_kind_name,
                Second_kind_id = ad.Second_kind_id,
                Second_kind_name = ad.Second_kind_name,
                Third_kind_id = ad.Third_kind_id,
                Third_kind_name = ad.Third_kind_name,
                Engage_type = ad.Engage_type,
                Major_kind_id = ad.Major_kind_id,
                Major_kind_name = ad.Major_kind_name,
                Major_id = ad.Major_id,
                Major_name = ad.Major_name,
                Human_amount = ad.Human_amount,
                Deadline = ad.Deadline,
                Register = ad.Register,
                Changer = ad.Changer,
                Change_time = ad.Change_time,
                Regist_time = ad.Regist_time,
                Major_describe = ad.Major_describe,
                Engage_required = ad.Engage_required

            };
            return cffkm;
        }

        public async Task<int> Update(Engage_major_release_Model ad)
        {
            Engage_major_release hm = new Engage_major_release()
            {
                Mre_id=ad.Mre_id,
                Changer=ad.Changer,
                Change_time=ad.Change_time,
                Major_describe=ad.Major_describe,
                Engage_required=ad.Engage_required,
            };
            hR_DBContext.Engage_major_releases.Attach(hm);
            hR_DBContext.Entry(hm).Property(e => e.Changer).IsModified = true;
            hR_DBContext.Entry(hm).Property(e => e.Change_time).IsModified = true;
            hR_DBContext.Entry(hm).Property(e => e.Major_describe).IsModified = true;
            hR_DBContext.Entry(hm).Property(e => e.Engage_required).IsModified = true;
            return await hR_DBContext.SaveChangesAsync();
        }
    }
}
