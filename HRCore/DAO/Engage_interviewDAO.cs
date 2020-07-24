using System;
using System.Collections.Generic;
using System.Text;
using Model;
using EFEntity;
using IDAO;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAO
{
   public class Engage_interviewDAO:IEngage_interviewDAO
    {
        private readonly HR_DBContext hR_DBContext;
        public Engage_interviewDAO(HR_DBContext hR_DBContext)
        {
            this.hR_DBContext = hR_DBContext;
        }

        public Task<int> Add(Engage_interview_Model eim)
        {
            Engage_interview abc = new Engage_interview()
            {
             Ein_id=eim.Ein_id,
             Human_name=eim.Human_name,
             Interview_amount=eim.Interview_amount,
             Human_major_kind_id=eim.Human_major_kind_id,
             Human_major_kind_name=eim.Human_major_kind_name,
             Human_major_id=eim.Human_major_id,
             Human_major_name=eim.Human_major_name,
             Image_degree=eim.Image_degree,
             Foreign_language_degree=eim.Foreign_language_degree,
                Interview_comment=eim.Interview_comment,
             Native_language_degree =eim.Native_language_degree,
             Response_speed_degree=eim.Response_speed_degree,
             EQ_degree=eim.EQ_degree,
             IQ_degree=eim.IQ_degree,
             Multi_quality_degree=eim.Multi_quality_degree,
             Register=eim.Register,
             Checker=eim.Checker,
             Registe_time=eim.Registe_time,
             Check_time=eim.Check_time,
             Resume_id=eim.Resume_id,
             Result=eim.Result,            
        
             Check_comment=eim.Check_comment,
             Interview_status=eim.Interview_status,
             Check_status=eim.Check_status
            
            };
            hR_DBContext.Engage_interviews.Add(abc);
            return hR_DBContext.SaveChangesAsync();
        
    }

        public Engage_interview_Model CfSelectBy(int id)
        {
            Engage_interview eim = hR_DBContext.Engage_interviews.Find(id);
            Engage_interview_Model cfk = new Engage_interview_Model()
            {
               Ein_id=eim.Ein_id,
                Human_name = eim.Human_name,
                Interview_amount = eim.Interview_amount,
                Human_major_kind_id = eim.Human_major_kind_id,
                Human_major_kind_name = eim.Human_major_kind_name,
                Human_major_id = eim.Human_major_id,
                Human_major_name = eim.Human_major_name,
                Image_degree = eim.Image_degree,
                Foreign_language_degree = eim.Foreign_language_degree,
                Interview_comment = eim.Interview_comment,
                Native_language_degree = eim.Native_language_degree,
                Response_speed_degree = eim.Response_speed_degree,
                EQ_degree = eim.EQ_degree,
                IQ_degree = eim.IQ_degree,
                Multi_quality_degree = eim.Multi_quality_degree,
                Register = eim.Register,
                Checker = eim.Checker,
                Registe_time = eim.Registe_time,
                Check_time = eim.Check_time,
                Resume_id = eim.Resume_id,
                Result = eim.Result,
                Check_comment = eim.Check_comment,
                Interview_status = eim.Interview_status,
                Check_status = eim.Check_status
            };
            return cfk;
        }

        public List<Engage_interview_Model> FenYe(FenYeModel fen)
        {
            List<Engage_interview_Model> list = new List<Engage_interview_Model>();

            SqlParameter[] ps = {
                    new SqlParameter(){ParameterName="@pageSize",Value=fen.PageSize},
                       new SqlParameter(){ParameterName="@keyName",Value=fen.KeyName},
                       new SqlParameter(){ParameterName="@tableName",Value=fen.TableName},
                       new SqlParameter(){ParameterName="@where",Value=fen.Where},
                       new SqlParameter(){ParameterName="@currentPage",Value=fen.CurrentPage},
                       new SqlParameter(){ParameterName="@rows",Direction=ParameterDirection.Output,SqlDbType=SqlDbType.Int},
                       new SqlParameter(){ParameterName="@pages",Direction=ParameterDirection.Output,SqlDbType=SqlDbType.Int}
                };
            var sql = hR_DBContext.Engage_interviews.FromSqlRaw($@"exec dbo.FenYeWhere @pageSize,@keyName,@tableName,@where,@currentPage,@rows out,@pages out", ps).ToList();
            foreach (var eim in sql)
            {
                Engage_interview_Model sm = new Engage_interview_Model()
                {
                   Ein_id=eim.Ein_id,
                  
                    Human_name=eim.Human_name,
                    Human_major_kind_name=eim.Human_major_kind_name,
                    Human_major_name=eim.Human_major_name,
                    Interview_amount=eim.Interview_amount,
                    Registe_time=eim.Registe_time,
                    Multi_quality_degree=eim.Multi_quality_degree,
                    Interview_status=eim.Interview_status
                };
                list.Add(sm);
            }
            fen.Pages = (int)ps[6].Value;
            fen.Rows = (int)ps[5].Value;

            return list;
        }

        public async Task<int> InterviewUpdate(Engage_interview_Model eim)
        {
            Engage_interview sd = new Engage_interview()
            {
             Ein_id=eim.Ein_id,
             Check_comment=eim.Check_comment,
             Checker=eim.Checker,
               
            };
            hR_DBContext.Engage_interviews.Attach(sd);
            hR_DBContext.Entry(sd).Property(e => e.Checker).IsModified = true;
            hR_DBContext.Entry(sd).Property(e => e.Check_comment).IsModified = true;            
            return await hR_DBContext.SaveChangesAsync();
        }

        public List<Engage_interview_Model> Selectinterview()
        {
            var item = hR_DBContext.Engage_interviews.ToList();
            List<Engage_interview_Model> list = new List<Engage_interview_Model>();
            foreach (var eim in item)
            {
                Engage_interview_Model cffkm = new Engage_interview_Model()
                {
                    Ein_id = eim.Ein_id,
                    Human_name = eim.Human_name,
                    Interview_amount = eim.Interview_amount,
                    Human_major_kind_id = eim.Human_major_kind_id,
                    Human_major_kind_name = eim.Human_major_kind_name,
                    Human_major_id = eim.Human_major_id,
                    Human_major_name = eim.Human_major_name,
                    Image_degree = eim.Image_degree,
                    Foreign_language_degree = eim.Foreign_language_degree,
                    Interview_comment = eim.Interview_comment,
                    Native_language_degree = eim.Native_language_degree,
                    Response_speed_degree = eim.Response_speed_degree,
                    EQ_degree = eim.EQ_degree,
                    IQ_degree = eim.IQ_degree,
                    Multi_quality_degree = eim.Multi_quality_degree,
                    Register = eim.Register,
                    Checker = eim.Checker,
                    Registe_time = eim.Registe_time,
                    Check_time = eim.Check_time,
                    Resume_id = eim.Resume_id,
                    Result = eim.Result,
                    //Check_comment = eim.Check_comment,
                    Interview_status = eim.Interview_status,
                    Check_status = eim.Check_status
                };
                list.Add(cffkm);
            }
           
            return list;
        }

        public async Task<int> Update(Engage_resume_Model ad)
        {
            Engage_resume sb = new Engage_resume()
            {
                Res_id=ad.Res_id,
              Pass_passComment=ad.Pass_passComment,
                Pass_checkComment=ad.Pass_checkComment,
            };
            hR_DBContext.Engage_resumes.Attach(sb);
     
            hR_DBContext.Entry(sb).Property(e => e.Pass_checkComment).IsModified = true;
            hR_DBContext.Entry(sb).Property(e => e.Pass_passComment).IsModified = true;
            return await hR_DBContext.SaveChangesAsync();
        }

       
    }
}
