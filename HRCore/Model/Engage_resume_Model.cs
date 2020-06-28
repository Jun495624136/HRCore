using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //    /* 创建新表 engage_resume。                                                                      */
    ///* engage_resume : 简历管理                                                                     */
    ///* 	res_id : 主键，自动增长列                                                                       */
    ///* 	human_name : 姓名                                                                         */
    ///* 	engage_type : 招聘类型                                                                      */
    ///* 	human_address : 地址                                                                      */
    ///* 	human_postcode : 邮编                                                                     */
    ///* 	human_major_kind_id : 职位分类编号                                                            */
    ///* 	human_major_kind_name : 职位分类名称                                                          */
    ///* 	human_major_id : 职位编号                                                                   */
    ///* 	human_major_name : 职位名称                                                                 */
    ///* 	human_telephone : 电话号码                                                                  */
    ///* 	human_homephone : 家庭电话                                                                  */
    ///* 	human_mobilephone : 手机                                                                  */
    ///* 	human_email : Email                                                                     */
    ///* 	human_hobby : 兴趣爱好                                                                      */
    ///* 	human_specility : 特长                                                                    */
    ///* 	human_sex : 性别                                                                          */
    ///* 	human_religion : 宗教信仰                                                                   */
    ///* 	human_party : 政治面貌                                                                      */
    ///* 	human_nationality : 国籍                                                                  */
    ///* 	human_race : 民族                                                                         */
    ///* 	human_birthday : 生日                                                                     */
    ///* 	human_age : 年龄                                                                          */
    ///* 	human_educated_degree : 教育程度                                                            */
    ///* 	human_educated_years : 教育年限                                                             */
    ///* 	human_educated_major : 专业                                                               */
    ///* 	human_college : 毕业院校                                                                    */
    ///* 	human_idcard : 身份证号                                                                     */
    ///* 	human_birthplace : 出生地                                                                  */
    ///* 	demand_salary_standard : 薪酬标准                                                           */
    ///* 	human_history_records : 个人履历                                                            */
    ///* 	remark : 备注                                                                             */
    ///* 	recomandation : 推荐意见                                                                    */
    ///* 	human_picture : 照片                                                                      */
    ///* 	attachment_name : 档案附件                                                                  */
    ///* 	check_status : 复核状态                                                                     */
    ///* 	register : 登记人                                                                          */
    ///* 	regist_time : 登记时间                                                                      */
    ///* 	checker : 复核人姓名                                                                         */
    ///* 	check_time : 复核时间                                                                       */
    ///* 	interview_status : 面试状态                                                                 */
    ///* 	total_points : 总分                                                                       */
    ///* 	test_amount : 考试次数                                                                      */
    ///* 	test_checker : 测试复核人                                                                    */
    ///* 	test_check_time : 测试复核时间                                                                */
    ///* 	pass_register : 通过登记人姓名                                                                 */
    ///* 	pass_regist_time : 通过登记时间                                                               */
    ///* 	pass_checker : 通过复核人姓名                                                                  */
    ///* 	pass_check_time : 通过复核时间                                                                */
    ///* 	pass_check_status : 通过的复核状态
    //	pass_checkComment:录用申请审核意见
    //	pass_passComment:录用申请审批意见 
   public class Engage_resume_Model
    {
        [Key]
        public int Res_id { get; set; }
        public string Human_name { get; set; }
        public string Engage_type { get; set; }
        public string Human_address { get; set; }
        public string Human_postcode { get; set; }
        public string Human_major_kind_id { get; set; }
        public string Human_major_kind_name { get; set; }
        public string Human_major_id { get; set; }
        public string Human_major_name { get; set; }
        public string Human_telephone { get; set; }
        public string Human_homephone { get; set; }
        public string Human_mobilephone { get; set; }
        public string Human_email { get; set; }
        public string Human_hobby { get; set; }
        public string Human_specility { get; set; }
        public string Human_sex { get; set; }
        public string Human_religion { get; set; }
        public string Human_party { get; set; }
        public string Human_nationality { get; set; }
        public string Human_race { get; set; }
        public DateTime Human_birthday { get; set; }
        public int Human_age { get; set; }
        public string Human_educated_degree { get; set; }
        public int Human_educated_years { get; set; }
        public string Human_educated_major { get; set; }
        public string Human_college { get; set; }
        public string Human_idcard { get; set; }
        public string Human_birthplace { get; set; }
        public double Demand_salary_standard { get; set; }
        public string Human_history_records { get; set; }
        public string Remark { get; set; }
        public string Recomandation { get; set; }
        public string Human_picture { get; set; }
        public string Attachment_name { get; set; }
        public int Check_status { get; set; }
        public string Register { get; set; }
        public DateTime Regist_time { get; set; }
        public string Checker { get; set; }
        public DateTime Check_time { get; set; }
        public int Interview_status { get; set; }
        public double Total_points { get; set; }
        public int Test_amount { get; set; }
        public string Test_checker { get; set; }
        public DateTime Test_check_time { get; set; }
        public string Pass_register { get; set; }
        public DateTime Pass_regist_time { get; set; }
        public string Pass_checker { get; set; }
        public DateTime Pass_check_time { get; set; }
        public int Pass_check_status { get; set; }
        public string Pass_checkComment { get; set; }
        public string Pass_passComment { get; set; }
      
    }
}
