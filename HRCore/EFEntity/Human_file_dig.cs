using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntity
{
    //    /* 创建新表 HumanFile_dig。                                                                     */
    ///* human_file_dig : 记录人力资源档案所做的任何更改                                                         */
    ///* 	hfd_id : 主键，自动增长列                                                                       */
    ///* 	human_id : 档案编号                                                                         */
    ///* 	first_kind_id : 一级机构编号                                                                  */
    ///* 	first_kind_name : 一级机构名称                                                                */
    ///* 	second_kind_id : 二级机构编号                                                                 */
    ///* 	second_kind_name : 二级机构名称                                                               */
    ///* 	third_kind_id : 三级机构编号                                                                  */
    ///* 	third_kind_name : 三级机构名称                                                                */
    ///* 	human_name : 姓名                                                                         */
    ///* 	human_address : 地址                                                                      */
    ///* 	human_postcode : 邮政编码                                                                   */
    ///* 	human_pro_designation : 职称                                                              */
    ///* 	human_major_kind_id : 职位分类编号                                                            */
    ///* 	human_major_kind_name : 职位分类名称                                                          */
    ///* 	human_major_id : 职位编号                                                                   */
    ///* 	hunma_major_name : 职位名称                                                                 */
    ///* 	human_telephone : 电话                                                                    */
    ///* 	human_mobilephone : 手机号码                                                                */
    ///* 	human_bank : 开户银行                                                                       */
    ///* 	human_account : 银行帐号                                                                    */
    ///* 	human_qq : QQ号码                                                                         */
    ///* 	human_email : 电子邮件                                                                      */
    ///* 	human_hobby : 爱好                                                                        */
    ///* 	human_speciality : 特长                                                                   */
    ///* 	human_sex : 性别                                                                          */
    ///* 	human_religion : 宗教信仰                                                                   */
    ///* 	human_party : 政治面貌                                                                      */
    ///* 	human_nationality : 国籍                                                                  */
    ///* 	human_race : 民族                                                                         */
    ///* 	human_birthday : 出生日期                                                                   */
    ///* 	human_birthplace : 出生地                                                                  */
    ///* 	human_age : 年龄                                                                          */
    ///* 	human_educated_degree : 学历                                                              */
    ///* 	human_educated_years : 教育年限                                                             */
    ///* 	human_educated_major : 学历专业                                                             */
    ///* 	human_society_security_id : 社会保障号                                                       */
    ///* 	human_id_card : 身份证号                                                                    */
    ///* 	remark : 备注                                                                             */
    ///* 	salary_standard_id : 薪酬标准编号                                                             */
    ///* 	salary_standard_name : 薪酬标准名称                                                           */
    ///* 	salary_sum : 基本薪酬总额                                                                     */
    ///* 	demand_salaray_sum : 应发薪酬总额                                                             */
    ///* 	paid_salary_sum : 实发薪酬总额                                                                */
    ///* 	major_change_amount : 调动次数                                                              */
    ///* 	bonus_amount : 激励累计次数                                                                   */
    ///* 	training_amount : 培训累计次数                                                                */
    ///* 	file_chang_amount : 档案变更累计次数                                                            */
    ///* 	human_histroy_records : 简历                                                              */
    ///* 	human_family_membership : 家庭关系                                                          */
    ///* 	human_picture : 相片                                                                      */
    ///* 	attachment_name : 附件名称                                                                  */
    ///* 	check_status : 复核状态                                                                     */
    ///* 	register : 档案登记人                                                                        */
    ///* 	checker : 档案复核人                                                                         */
    ///* 	changer : 档案变更人                                                                         */
    ///* 	regist_time : 档案登记时间                                                                    */
    ///* 	check_time : 档案复核时间                                                                     */
    ///* 	change_time : 档案变更时间                                                                    */
    ///* 	lastly_change_time : 档案最近更改时间                                                           */
    ///* 	delete_time : 档案删除时间                                                                    */
    ///* 	recovery_time : 档案恢复时间                                                                  */
    ///* 	human_file_status : 档案状态 
    ///create table human_file_dig ( 
	//hfd_id smallint identity not null,
	//human_id varchar(30) null,
	//first_kind_id char (2) null,
	//first_kind_name varchar(60) null,
	//second_kind_id char (2) null,
	//second_kind_name varchar(60) null,
	//third_kind_id char (2) null,
	//third_kind_name varchar(60) null,
	//human_name varchar(60) null,
	//human_address varchar(200) null,
	//human_postcode varchar(10) null,
	//human_pro_designation varchar(60) null,
	//human_major_kind_id char (2) null,
	//human_major_kind_name varchar(60) null,
	//human_major_id char (2) null,
	//hunma_major_name varchar(60) null,
	//human_telephone varchar(20) null,
	//human_mobilephone char (11) null,
	//human_bank varchar(50) null,
	//human_account varchar(30) null,
	//human_qq varchar(15) null,
	//human_email varchar(50) null,
	//human_hobby varchar(60) null,
	//human_speciality varchar(60) null,
	//human_sex char (2) null,
	//human_religion varchar(50) null,
	//human_party varchar(50) null,
	//human_nationality varchar(50) null,
	//human_race varchar(50) null,
	//human_birthday datetime null,
	//human_birthplace varchar(50) null,
	//human_age smallint null,
	//human_educated_degree varchar(60) null,
	//human_educated_years smallint null,
	//human_educated_major varchar(60) null,
	//human_society_security_id varchar(30) null,
	//human_id_card varchar(20) not null,
	//remark text null,
	//salary_standard_id varchar(30) null,
	//salary_standard_name varchar(60) null,
	//salary_sum money null,
	//demand_salaray_sum money null,
	//paid_salary_sum money null,
	//major_change_amount smallint null,
	//bonus_amount smallint null,
	//training_amount smallint null,
	//file_chang_amount smallint null,
	//human_histroy_records text null,
	//human_family_membership text null,
	//human_picture varchar(255) null,
	//attachment_name varchar(255) null,
	//check_status smallint null,
	//register varchar(60) null,
	//checker varchar(60) null,
	//changer varchar(60) null,
	//regist_time datetime null,
	//check_time datetime null,
	//change_time datetime null,
	//lastly_change_time datetime null,
	//delete_time datetime null,
	//recovery_time datetime null,
	//human_file_status bit null) 
   public class Human_file_dig
    {
        [Key]
        public int Hfd_id { get; set; }
        public string Human_id { get; set; }
        public string First_kind_id { get; set; }
        public string First_kind_name { get; set; }
        public string Second_kind_id { get; set; }
        public string Second_kind_name { get; set; }
        public string Third_kind_id { get; set; }
        public string Third_kind_name { get; set; }
        public string Human_name { get; set; }
        public string Human_address { get; set; }
        public string Human_postcode { get; set; }
        public string Human_pro_designation { get; set; }
        public string Human_major_kind_id { get; set; }
        public string Human_major_kind_name { get; set; }
        public string Human_major_id { get; set; }
        public string Hunma_major_name { get; set; }
        public string Human_telephone { get; set; }
        public string Human_mobilephone { get; set; }
        public string Human_bank { get; set; }
        public string Human_account { get; set; }
        public string Human_qq { get; set; }
        public string Human_email { get; set; }
        public string Human_hobby { get; set; }
        public string Human_speciality { get; set; }
        public string Human_sex { get; set; }
        public string Human_religion { get; set; }
        public string Human_party { get; set; }
        public string Human_nationality { get; set; }
        public string Human_race { get; set; }
        public DateTime Human_birthday { get; set; }
        public string Human_birthplace { get; set; }
        public int Human_age { get; set; }
        public string Human_educated_degree { get; set; }
        public int Human_educated_years { get; set; }
        public string Human_educated_major { get; set; }
        public string Human_society_security_id { get; set; }
        public string Human_id_card { get; set; }
        public string Remark { get; set; }
        public string Salary_standard_id { get; set; }
        public string Salary_standard_name { get; set; }
        public double Salary_sum { get; set; }
        public double Demand_salaray_sum { get; set; }
        public double Paid_salary_sum { get; set; }
        public int Major_change_amount { get; set; }
        public int Bonus_amount { get; set; }
        public int Training_amount { get; set; }
        public int File_chang_amount { get; set; }
        public string Human_histroy_records { get; set; }
        public string Human_family_membership { get; set; }
        public string Human_picture { get; set; }
        public string Attachment_name { get; set; }
        public int Check_status { get; set; }
        public string Register { get; set; }
        public string Checker { get; set; }
        public string Changer { get; set; }
        public DateTime Regist_time { get; set; }
        public DateTime Check_time { get; set; }
        public DateTime Change_time { get; set; }
        public DateTime Lastly_change_time { get; set; }
        public DateTime Delete_time { get; set; }
        public DateTime Recovery_time { get; set; }
        public bool Human_file_status { get; set; }
    }
}
