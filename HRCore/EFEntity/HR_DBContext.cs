using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
   public class HR_DBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=HR_DBCore;Integrated Security=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //写对应的配置信息
            var use = modelBuilder.Entity<Users>();
            use.ToTable(nameof(Users));
            use.HasKey("U_id");

            var tra = modelBuilder.Entity<Training>();
            tra.ToTable(nameof(Training));
            tra.HasKey("Tra_id");

            var yh = modelBuilder.Entity<YHquanxian>();
            yh.ToTable(nameof(YHquanxian));
            yh.HasKey("YHid");

            var sf = modelBuilder.Entity<SFquanxian>();
            sf.ToTable(nameof(SFquanxian));
            sf.HasKey("id");

            var ssd = modelBuilder.Entity<Salary_standard_details>();
            ssd.ToTable(nameof(Salary_standard_details));
            ssd.HasKey("Sdt_id");

            var ss = modelBuilder.Entity<Salary_standard>();
            ss.ToTable(nameof(Salary_standard));
            ss.HasKey("Ssd_id");

            var sgs = modelBuilder.Entity<Salary_grant_details>();
            sgs.ToTable(nameof(Salary_grant_details));
            sgs.HasKey("Grd_id");

            var sg = modelBuilder.Entity<Salary_grant>();
            sg.ToTable(nameof(Salary_grant));
            sg.HasKey("Sgr_id");

            var mc = modelBuilder.Entity<Major_change>();
            mc.ToTable(nameof(Major_change));
            mc.HasKey("Mch_id");

            var js = modelBuilder.Entity<JueSe>();
            js.ToTable(nameof(JueSe));
            js.HasKey("JueSe_id");

            var hfd = modelBuilder.Entity<Human_file_dig>();
            hfd.ToTable(nameof(Human_file_dig));
            hfd.HasKey("Hfd_id");

            var hf = modelBuilder.Entity<Human_file>();
            hf.ToTable(nameof(Human_file));
            hf.HasKey("Huf_id");

            var es = modelBuilder.Entity<Engage_subjects>();
            es.ToTable(nameof(Engage_subjects));
            es.HasKey("Sub_id");

            var er = modelBuilder.Entity<Engage_resume>();
            er.ToTable(nameof(Engage_resume));
            er.HasKey("Res_id");

            var emr = modelBuilder.Entity<Engage_major_release>();
            emr.ToTable(nameof(Engage_major_release));
            emr.HasKey("Mre_id");

            var ei = modelBuilder.Entity<Engage_interview>();
            ei.ToTable(nameof(Engage_interview));
            ei.HasKey("Ein_id");

            var ees = modelBuilder.Entity<Engage_exam_details>();
            ees.ToTable(nameof(Engage_exam_details));
            ees.HasKey("Exd_id");

            var ea = modelBuilder.Entity<Engage_exam>();
            ea.ToTable(nameof(Engage_exam));
            ea.HasKey("Exa_id");

            var ead = modelBuilder.Entity<Engage_answer_details>();
            ead.ToTable(nameof(Engage_answer_details));
            ead.HasKey("And_id");

            var eaa = modelBuilder.Entity<Engage_answer>();
            eaa.ToTable(nameof(Engage_answer));
            eaa.HasKey("Ans_id");

            var cqsk = modelBuilder.Entity<Config_question_second_kind>();
            cqsk.ToTable(nameof(Config_question_second_kind));
            cqsk.HasKey("Qsk_id");

            var cqfk = modelBuilder.Entity<Config_question_first_kind>();
            cqfk.ToTable(nameof(Config_question_first_kind));
            cqfk.HasKey("Qfk_id");

            var cpc = modelBuilder.Entity<Config_public_char>();
            cpc.ToTable(nameof(Config_public_char));
            cpc.HasKey("Pbc_id");

            var cpk = modelBuilder.Entity<Config_primary_key>();
            cpk.ToTable(nameof(Config_primary_key));
            cpk.HasKey("Prk_id");

            var cmk = modelBuilder.Entity<Config_major_kind>();
            cmk.ToTable(nameof(Config_major_kind));
            cmk.HasKey("Mfk_id");

            var cm = modelBuilder.Entity<Config_major>();
            cm.ToTable(nameof(Config_major));
            cm.HasKey("Mak_id");

            var cqtk = modelBuilder.Entity<Config_file_third_kind>();
            cqtk.ToTable(nameof(Config_file_third_kind));
            cqtk.HasKey("Ftk_id");

            var cfsk = modelBuilder.Entity<Config_file_second_kind>();
            cfsk.ToTable(nameof(Config_file_second_kind));
            cfsk.HasKey("Fsk_id");

            var cffk = modelBuilder.Entity<Config_file_first_kind>();
            cffk.ToTable(nameof(Config_file_first_kind));
            cffk.HasKey("Ffk_id");

            var bo = modelBuilder.Entity<Bonus>();
            bo.ToTable(nameof(Bonus));
            bo.HasKey("Bon_id");
        }

        public DbSet<Users> User { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Salary_standard_details> Salary_standard_detailss { get; set; }
        public DbSet<Salary_standard> Salary_standards { get; set; }
        public DbSet<Salary_grant_details> Salary_grant_detailss { get; set; }
        public DbSet<Salary_grant> Salary_grants { get; set; }
        public DbSet<Major_change> Major_changes { get; set; }
        public DbSet<Human_file_dig> Human_file_digs { get; set; }
        public DbSet<Human_file> Human_files { get; set; }
        public DbSet<Engage_subjects> Engage_subjectss { get; set; }
        public DbSet<Engage_resume> Engage_resumes { get; set; }
        public DbSet<Engage_major_release> Engage_major_releases { get; set; }
        public DbSet<Engage_interview> Engage_interviews { get; set; }
        public DbSet<Engage_exam_details> Engage_exam_detailss { get; set; }
        public DbSet<Engage_exam> Engage_exams { get; set; }
        public DbSet<Engage_answer_details> Engage_answer_detailss { get; set; }
        public DbSet<Engage_answer> Engage_answers { get; set; }
        public DbSet<Config_question_second_kind> Config_question_second_kinds { get; set; }
        public DbSet<Config_question_first_kind> Config_question_first_kinds { get; set; }
        public DbSet<Config_public_char> Config_public_chars { get; set; }
        public DbSet<Config_primary_key> Config_primary_keys { get; set; }
        public DbSet<Config_major_kind> Config_major_kinds { get; set; }
        public DbSet<Config_major> Config_majors { get; set; }
        public DbSet<Config_file_third_kind> Config_file_third_kinds { get; set; }
        public DbSet<Config_file_second_kind> Config_file_second_kinds { get; set; }
        public DbSet<Config_file_first_kind> Config_file_first_kinds { get; set; }
        public DbSet<Bonus> Bonuss { get; set; }
        public DbSet<JueSe> JueSes { get; set; }
        public DbSet<YHquanxian> YHquanxians { get; set; }
        public DbSet<SFquanxian>  SFquanxians { get; set; }

    }
}
