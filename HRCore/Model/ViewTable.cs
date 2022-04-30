using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class ViewTable
    {
        public List<Salary_standard_Model> Salary_standard { get; set; }
        public List<Salary_standard_details_Model> Salary_standard_details { get; set; }
        public List<Salary_grant_details_Model> Salary_grant_details { get; set; }
        public List<Human_file_Model> Human_file { get; set; }
        public List<Salary_grant_Model> salary_Grants { get; set; }
        public List<Engage_resume_Model> engage_Resumes { get; set; }
        public List<Engage_interview_Model> engage_Interview_s { get; set; }
        public List<Human_file_Model> human_File_Models { get; set; }
 
    }
}
