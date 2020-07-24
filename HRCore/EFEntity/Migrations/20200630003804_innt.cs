using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFEntity.Migrations
{
    public partial class innt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bonus",
                columns: table => new
                {
                    Bon_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Major_kind_id = table.Column<string>(nullable: true),
                    Major_kind_name = table.Column<string>(nullable: true),
                    Major_id = table.Column<string>(nullable: true),
                    Major_name = table.Column<string>(nullable: true),
                    Human_id = table.Column<string>(nullable: true),
                    Human_name = table.Column<string>(nullable: true),
                    Bonus_item = table.Column<string>(nullable: true),
                    Bonus_worth = table.Column<double>(nullable: false),
                    Bonus_degree = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    Register = table.Column<string>(nullable: true),
                    Checker = table.Column<string>(nullable: true),
                    Regist_time = table.Column<DateTime>(nullable: false),
                    Check_time = table.Column<DateTime>(nullable: false),
                    Check_status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bonus", x => x.Bon_id);
                });

            migrationBuilder.CreateTable(
                name: "Config_file_first_kind",
                columns: table => new
                {
                    Ffk_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_kind_id = table.Column<string>(nullable: true),
                    First_kind_name = table.Column<string>(nullable: true),
                    First_kind_salary_id = table.Column<string>(nullable: true),
                    First_kind_sale_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config_file_first_kind", x => x.Ffk_id);
                });

            migrationBuilder.CreateTable(
                name: "Config_file_second_kind",
                columns: table => new
                {
                    Fsk_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_kind_id = table.Column<string>(nullable: true),
                    First_kind_name = table.Column<string>(nullable: true),
                    Second_kind_id = table.Column<string>(nullable: true),
                    Second_kind_name = table.Column<string>(nullable: true),
                    Second_salary_id = table.Column<string>(nullable: true),
                    Second_sale_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config_file_second_kind", x => x.Fsk_id);
                });

            migrationBuilder.CreateTable(
                name: "Config_file_third_kind",
                columns: table => new
                {
                    Ftk_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_kind_id = table.Column<string>(nullable: true),
                    First_kind_name = table.Column<string>(nullable: true),
                    Second_kind_id = table.Column<string>(nullable: true),
                    Second_kind_name = table.Column<string>(nullable: true),
                    Third_kind_id = table.Column<string>(nullable: true),
                    Third_kind_name = table.Column<string>(nullable: true),
                    Third_kind_sale_id = table.Column<string>(nullable: true),
                    Third_kind_is_retail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config_file_third_kind", x => x.Ftk_id);
                });

            migrationBuilder.CreateTable(
                name: "Config_major",
                columns: table => new
                {
                    Mak_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Major_kind_id = table.Column<string>(nullable: true),
                    Major_kind_name = table.Column<string>(nullable: true),
                    Major_id = table.Column<string>(nullable: true),
                    Major_name = table.Column<string>(nullable: true),
                    Test_amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config_major", x => x.Mak_id);
                });

            migrationBuilder.CreateTable(
                name: "Config_major_kind",
                columns: table => new
                {
                    Mfk_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Major_kind_id = table.Column<string>(nullable: true),
                    Major_kind_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config_major_kind", x => x.Mfk_id);
                });

            migrationBuilder.CreateTable(
                name: "Config_primary_key",
                columns: table => new
                {
                    Prk_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Primary_key_table = table.Column<string>(nullable: true),
                    Primary_key = table.Column<string>(nullable: true),
                    Key_name = table.Column<string>(nullable: true),
                    Primary_key_status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config_primary_key", x => x.Prk_id);
                });

            migrationBuilder.CreateTable(
                name: "Config_public_char",
                columns: table => new
                {
                    Pbc_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attribute_kind = table.Column<string>(nullable: true),
                    Attribute_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config_public_char", x => x.Pbc_id);
                });

            migrationBuilder.CreateTable(
                name: "Config_question_first_kind",
                columns: table => new
                {
                    Qfk_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_kind_id = table.Column<string>(nullable: true),
                    First_kind_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config_question_first_kind", x => x.Qfk_id);
                });

            migrationBuilder.CreateTable(
                name: "Config_question_second_kind",
                columns: table => new
                {
                    Qsk_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_kind_id = table.Column<string>(nullable: true),
                    First_kind_name = table.Column<string>(nullable: true),
                    Second_kind_id = table.Column<string>(nullable: true),
                    Second_kind_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config_question_second_kind", x => x.Qsk_id);
                });

            migrationBuilder.CreateTable(
                name: "Engage_answer",
                columns: table => new
                {
                    Ans_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer_number = table.Column<string>(nullable: true),
                    Exam_number = table.Column<string>(nullable: true),
                    Resume_id = table.Column<int>(nullable: false),
                    Interview_id = table.Column<int>(nullable: false),
                    Human_name = table.Column<string>(nullable: true),
                    Human_idcard = table.Column<string>(nullable: true),
                    Major_kind_id = table.Column<string>(nullable: true),
                    Major_kind_name = table.Column<string>(nullable: true),
                    Major_id = table.Column<string>(nullable: true),
                    Major_name = table.Column<string>(nullable: true),
                    Test_time = table.Column<DateTime>(nullable: false),
                    Use_time = table.Column<string>(nullable: true),
                    Total_point = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engage_answer", x => x.Ans_id);
                });

            migrationBuilder.CreateTable(
                name: "Engage_answer_details",
                columns: table => new
                {
                    And_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer_number = table.Column<string>(nullable: true),
                    Subject_id = table.Column<int>(nullable: false),
                    Answer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engage_answer_details", x => x.And_id);
                });

            migrationBuilder.CreateTable(
                name: "Engage_exam",
                columns: table => new
                {
                    Exa_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Exam_number = table.Column<string>(nullable: true),
                    Major_kind_id = table.Column<string>(nullable: true),
                    Major_kind_name = table.Column<string>(nullable: true),
                    Major_id = table.Column<string>(nullable: true),
                    Major_name = table.Column<string>(nullable: true),
                    Register = table.Column<string>(nullable: true),
                    Regist_time = table.Column<DateTime>(nullable: false),
                    Limite_time = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engage_exam", x => x.Exa_id);
                });

            migrationBuilder.CreateTable(
                name: "Engage_exam_details",
                columns: table => new
                {
                    Exd_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Exam_number = table.Column<string>(nullable: true),
                    First_kind_id = table.Column<string>(nullable: true),
                    First_kind_name = table.Column<string>(nullable: true),
                    Second_kind_id = table.Column<string>(nullable: true),
                    Second_kind_name = table.Column<string>(nullable: true),
                    Question_amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engage_exam_details", x => x.Exd_id);
                });

            migrationBuilder.CreateTable(
                name: "Engage_interview",
                columns: table => new
                {
                    Ein_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Human_name = table.Column<string>(nullable: true),
                    Interview_amount = table.Column<int>(nullable: false),
                    Human_major_kind_id = table.Column<string>(nullable: true),
                    Human_major_kind_name = table.Column<string>(nullable: true),
                    Human_major_id = table.Column<string>(nullable: true),
                    Human_major_name = table.Column<string>(nullable: true),
                    Image_degree = table.Column<string>(nullable: true),
                    Native_language_degree = table.Column<string>(nullable: true),
                    Foreign_language_degree = table.Column<string>(nullable: true),
                    Response_speed_degree = table.Column<string>(nullable: true),
                    EQ_degree = table.Column<string>(nullable: true),
                    IQ_degree = table.Column<string>(nullable: true),
                    Multi_quality_degree = table.Column<string>(nullable: true),
                    Register = table.Column<string>(nullable: true),
                    Checker = table.Column<string>(nullable: true),
                    Registe_time = table.Column<DateTime>(nullable: false),
                    Check_time = table.Column<DateTime>(nullable: false),
                    Resume_id = table.Column<int>(nullable: false),
                    Result = table.Column<string>(nullable: true),
                    Interview_comment = table.Column<string>(nullable: true),
                    Check_comment = table.Column<string>(nullable: true),
                    Interview_status = table.Column<int>(nullable: false),
                    Check_status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engage_interview", x => x.Ein_id);
                });

            migrationBuilder.CreateTable(
                name: "Engage_major_release",
                columns: table => new
                {
                    Mre_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_kind_id = table.Column<string>(nullable: true),
                    First_kind_name = table.Column<string>(nullable: true),
                    Second_kind_id = table.Column<string>(nullable: true),
                    Second_kind_name = table.Column<string>(nullable: true),
                    Third_kind_id = table.Column<string>(nullable: true),
                    Third_kind_name = table.Column<string>(nullable: true),
                    Major_kind_id = table.Column<string>(nullable: true),
                    Major_kind_name = table.Column<string>(nullable: true),
                    Major_id = table.Column<string>(nullable: true),
                    Major_name = table.Column<string>(nullable: true),
                    Human_amount = table.Column<int>(nullable: false),
                    Engage_type = table.Column<string>(nullable: true),
                    Deadline = table.Column<DateTime>(nullable: false),
                    Register = table.Column<string>(nullable: true),
                    Changer = table.Column<string>(nullable: true),
                    Regist_time = table.Column<DateTime>(nullable: false),
                    Change_time = table.Column<DateTime>(nullable: false),
                    Major_describe = table.Column<string>(nullable: true),
                    Engage_required = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engage_major_release", x => x.Mre_id);
                });

            migrationBuilder.CreateTable(
                name: "Engage_resume",
                columns: table => new
                {
                    Res_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Human_name = table.Column<string>(nullable: true),
                    Engage_type = table.Column<string>(nullable: true),
                    Human_address = table.Column<string>(nullable: true),
                    Human_postcode = table.Column<string>(nullable: true),
                    Human_major_kind_id = table.Column<string>(nullable: true),
                    Human_major_kind_name = table.Column<string>(nullable: true),
                    Human_major_id = table.Column<string>(nullable: true),
                    Human_major_name = table.Column<string>(nullable: true),
                    Human_telephone = table.Column<string>(nullable: true),
                    Human_homephone = table.Column<string>(nullable: true),
                    Human_mobilephone = table.Column<string>(nullable: true),
                    Human_email = table.Column<string>(nullable: true),
                    Human_hobby = table.Column<string>(nullable: true),
                    Human_specility = table.Column<string>(nullable: true),
                    Human_sex = table.Column<string>(nullable: true),
                    Human_religion = table.Column<string>(nullable: true),
                    Human_party = table.Column<string>(nullable: true),
                    Human_nationality = table.Column<string>(nullable: true),
                    Human_race = table.Column<string>(nullable: true),
                    Human_birthday = table.Column<DateTime>(nullable: false),
                    Human_age = table.Column<int>(nullable: false),
                    Human_educated_degree = table.Column<string>(nullable: true),
                    Human_educated_years = table.Column<int>(nullable: false),
                    Human_educated_major = table.Column<string>(nullable: true),
                    Human_college = table.Column<string>(nullable: true),
                    Human_idcard = table.Column<string>(nullable: true),
                    Human_birthplace = table.Column<string>(nullable: true),
                    Demand_salary_standard = table.Column<double>(nullable: false),
                    Human_history_records = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    Recomandation = table.Column<string>(nullable: true),
                    Human_picture = table.Column<string>(nullable: true),
                    Attachment_name = table.Column<string>(nullable: true),
                    Check_status = table.Column<int>(nullable: false),
                    Register = table.Column<string>(nullable: true),
                    Regist_time = table.Column<DateTime>(nullable: false),
                    Checker = table.Column<string>(nullable: true),
                    Check_time = table.Column<DateTime>(nullable: false),
                    Interview_status = table.Column<int>(nullable: false),
                    Total_points = table.Column<double>(nullable: false),
                    Test_amount = table.Column<int>(nullable: false),
                    Test_checker = table.Column<string>(nullable: true),
                    Test_check_time = table.Column<DateTime>(nullable: false),
                    Pass_register = table.Column<string>(nullable: true),
                    Pass_regist_time = table.Column<DateTime>(nullable: false),
                    Pass_checker = table.Column<string>(nullable: true),
                    Pass_check_time = table.Column<DateTime>(nullable: false),
                    Pass_check_status = table.Column<int>(nullable: false),
                    Pass_checkComment = table.Column<string>(nullable: true),
                    Pass_passComment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engage_resume", x => x.Res_id);
                });

            migrationBuilder.CreateTable(
                name: "Engage_subjects",
                columns: table => new
                {
                    Sub_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_kind_id = table.Column<string>(nullable: true),
                    First_kind_name = table.Column<string>(nullable: true),
                    Second_kind_id = table.Column<string>(nullable: true),
                    Second_kind_name = table.Column<string>(nullable: true),
                    Register = table.Column<string>(nullable: true),
                    Regist_time = table.Column<DateTime>(nullable: false),
                    Derivation = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Key_a = table.Column<string>(nullable: true),
                    Key_b = table.Column<string>(nullable: true),
                    Key_c = table.Column<string>(nullable: true),
                    Key_d = table.Column<string>(nullable: true),
                    Key_e = table.Column<string>(nullable: true),
                    Correct_key = table.Column<string>(nullable: true),
                    Changer = table.Column<string>(nullable: true),
                    Change_time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engage_subjects", x => x.Sub_id);
                });

            migrationBuilder.CreateTable(
                name: "Human_file",
                columns: table => new
                {
                    Huf_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Human_id = table.Column<string>(nullable: true),
                    First_kind_id = table.Column<string>(nullable: true),
                    First_kind_name = table.Column<string>(nullable: true),
                    Second_kind_id = table.Column<string>(nullable: true),
                    Second_kind_name = table.Column<string>(nullable: true),
                    Third_kind_id = table.Column<string>(nullable: true),
                    Third_kind_name = table.Column<string>(nullable: true),
                    Human_name = table.Column<string>(nullable: true),
                    Human_address = table.Column<string>(nullable: true),
                    Human_postcode = table.Column<string>(nullable: true),
                    Human_pro_designation = table.Column<string>(nullable: true),
                    Human_major_kind_id = table.Column<string>(nullable: true),
                    Human_major_kind_name = table.Column<string>(nullable: true),
                    Human_major_id = table.Column<string>(nullable: true),
                    Hunma_major_name = table.Column<string>(nullable: true),
                    Human_telephone = table.Column<string>(nullable: true),
                    Human_mobilephone = table.Column<string>(nullable: true),
                    Human_bank = table.Column<string>(nullable: true),
                    Human_account = table.Column<string>(nullable: true),
                    Human_qq = table.Column<string>(nullable: true),
                    Human_email = table.Column<string>(nullable: true),
                    Human_hobby = table.Column<string>(nullable: true),
                    Human_speciality = table.Column<string>(nullable: true),
                    Human_sex = table.Column<string>(nullable: true),
                    Human_religion = table.Column<string>(nullable: true),
                    Human_party = table.Column<string>(nullable: true),
                    Human_nationality = table.Column<string>(nullable: true),
                    Human_race = table.Column<string>(nullable: true),
                    Human_birthday = table.Column<DateTime>(nullable: false),
                    Human_birthplace = table.Column<string>(nullable: true),
                    Human_age = table.Column<int>(nullable: false),
                    Human_educated_degree = table.Column<string>(nullable: true),
                    Human_educated_years = table.Column<int>(nullable: false),
                    Human_educated_major = table.Column<string>(nullable: true),
                    Human_society_security_id = table.Column<string>(nullable: true),
                    Human_id_card = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    Salary_standard_id = table.Column<string>(nullable: true),
                    Salary_standard_name = table.Column<string>(nullable: true),
                    Salary_sum = table.Column<double>(nullable: false),
                    Demand_salaray_sum = table.Column<double>(nullable: false),
                    Paid_salary_sum = table.Column<double>(nullable: false),
                    Major_change_amount = table.Column<int>(nullable: false),
                    Bonus_amount = table.Column<int>(nullable: false),
                    Training_amount = table.Column<int>(nullable: false),
                    File_chang_amount = table.Column<int>(nullable: false),
                    Human_histroy_records = table.Column<string>(nullable: true),
                    Human_family_membership = table.Column<string>(nullable: true),
                    Human_picture = table.Column<string>(nullable: true),
                    Attachment_name = table.Column<string>(nullable: true),
                    Check_status = table.Column<int>(nullable: false),
                    Register = table.Column<string>(nullable: true),
                    Checker = table.Column<string>(nullable: true),
                    Changer = table.Column<string>(nullable: true),
                    Regist_time = table.Column<DateTime>(nullable: false),
                    Check_time = table.Column<DateTime>(nullable: false),
                    Change_time = table.Column<DateTime>(nullable: false),
                    Lastly_change_time = table.Column<DateTime>(nullable: false),
                    Delete_time = table.Column<DateTime>(nullable: false),
                    Recovery_time = table.Column<DateTime>(nullable: false),
                    Human_file_status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Human_file", x => x.Huf_id);
                });

            migrationBuilder.CreateTable(
                name: "Human_file_dig",
                columns: table => new
                {
                    Hfd_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Human_id = table.Column<string>(nullable: true),
                    First_kind_id = table.Column<string>(nullable: true),
                    First_kind_name = table.Column<string>(nullable: true),
                    Second_kind_id = table.Column<string>(nullable: true),
                    Second_kind_name = table.Column<string>(nullable: true),
                    Third_kind_id = table.Column<string>(nullable: true),
                    Third_kind_name = table.Column<string>(nullable: true),
                    Human_name = table.Column<string>(nullable: true),
                    Human_address = table.Column<string>(nullable: true),
                    Human_postcode = table.Column<string>(nullable: true),
                    Human_pro_designation = table.Column<string>(nullable: true),
                    Human_major_kind_id = table.Column<string>(nullable: true),
                    Human_major_kind_name = table.Column<string>(nullable: true),
                    Human_major_id = table.Column<string>(nullable: true),
                    Hunma_major_name = table.Column<string>(nullable: true),
                    Human_telephone = table.Column<string>(nullable: true),
                    Human_mobilephone = table.Column<string>(nullable: true),
                    Human_bank = table.Column<string>(nullable: true),
                    Human_account = table.Column<string>(nullable: true),
                    Human_qq = table.Column<string>(nullable: true),
                    Human_email = table.Column<string>(nullable: true),
                    Human_hobby = table.Column<string>(nullable: true),
                    Human_speciality = table.Column<string>(nullable: true),
                    Human_sex = table.Column<string>(nullable: true),
                    Human_religion = table.Column<string>(nullable: true),
                    Human_party = table.Column<string>(nullable: true),
                    Human_nationality = table.Column<string>(nullable: true),
                    Human_race = table.Column<string>(nullable: true),
                    Human_birthday = table.Column<DateTime>(nullable: false),
                    Human_birthplace = table.Column<string>(nullable: true),
                    Human_age = table.Column<int>(nullable: false),
                    Human_educated_degree = table.Column<string>(nullable: true),
                    Human_educated_years = table.Column<int>(nullable: false),
                    Human_educated_major = table.Column<string>(nullable: true),
                    Human_society_security_id = table.Column<string>(nullable: true),
                    Human_id_card = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    Salary_standard_id = table.Column<string>(nullable: true),
                    Salary_standard_name = table.Column<string>(nullable: true),
                    Salary_sum = table.Column<double>(nullable: false),
                    Demand_salaray_sum = table.Column<double>(nullable: false),
                    Paid_salary_sum = table.Column<double>(nullable: false),
                    Major_change_amount = table.Column<int>(nullable: false),
                    Bonus_amount = table.Column<int>(nullable: false),
                    Training_amount = table.Column<int>(nullable: false),
                    File_chang_amount = table.Column<int>(nullable: false),
                    Human_histroy_records = table.Column<string>(nullable: true),
                    Human_family_membership = table.Column<string>(nullable: true),
                    Human_picture = table.Column<string>(nullable: true),
                    Attachment_name = table.Column<string>(nullable: true),
                    Check_status = table.Column<int>(nullable: false),
                    Register = table.Column<string>(nullable: true),
                    Checker = table.Column<string>(nullable: true),
                    Changer = table.Column<string>(nullable: true),
                    Regist_time = table.Column<DateTime>(nullable: false),
                    Check_time = table.Column<DateTime>(nullable: false),
                    Change_time = table.Column<DateTime>(nullable: false),
                    Lastly_change_time = table.Column<DateTime>(nullable: false),
                    Delete_time = table.Column<DateTime>(nullable: false),
                    Recovery_time = table.Column<DateTime>(nullable: false),
                    Human_file_status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Human_file_dig", x => x.Hfd_id);
                });

            migrationBuilder.CreateTable(
                name: "JueSe",
                columns: table => new
                {
                    JueSe_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JueSe_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JueSe", x => x.JueSe_id);
                });

            migrationBuilder.CreateTable(
                name: "Major_change",
                columns: table => new
                {
                    Mch_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_kind_id = table.Column<string>(nullable: true),
                    First_kind_name = table.Column<string>(nullable: true),
                    Second_kind_id = table.Column<string>(nullable: true),
                    Second_kind_name = table.Column<string>(nullable: true),
                    Third_kind_id = table.Column<string>(nullable: true),
                    Third_kind_name = table.Column<string>(nullable: true),
                    Major_kind_id = table.Column<string>(nullable: true),
                    Major_kind_name = table.Column<string>(nullable: true),
                    Major_id = table.Column<string>(nullable: true),
                    Major_name = table.Column<string>(nullable: true),
                    New_first_kind_id = table.Column<string>(nullable: true),
                    New_first_kind_name = table.Column<string>(nullable: true),
                    New_second_kind_id = table.Column<string>(nullable: true),
                    New_second_kind_name = table.Column<string>(nullable: true),
                    New_third_kind_id = table.Column<string>(nullable: true),
                    New_third_kind_name = table.Column<string>(nullable: true),
                    New_major_kind_id = table.Column<string>(nullable: true),
                    New_major_kind_name = table.Column<string>(nullable: true),
                    New_major_id = table.Column<string>(nullable: true),
                    New_major_name = table.Column<string>(nullable: true),
                    Human_id = table.Column<string>(nullable: true),
                    Human_name = table.Column<string>(nullable: true),
                    Salary_standard_id = table.Column<string>(nullable: true),
                    Salary_standard_name = table.Column<string>(nullable: true),
                    Salary_sum = table.Column<double>(nullable: false),
                    New_salary_standard_id = table.Column<string>(nullable: true),
                    New_salary_standard_name = table.Column<string>(nullable: true),
                    New_salary_sum = table.Column<double>(nullable: false),
                    Change_reason = table.Column<string>(nullable: true),
                    Check_reason = table.Column<string>(nullable: true),
                    Check_status = table.Column<int>(nullable: false),
                    Register = table.Column<string>(nullable: true),
                    Checker = table.Column<string>(nullable: true),
                    Regist_time = table.Column<DateTime>(nullable: false),
                    Check_time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Major_change", x => x.Mch_id);
                });

            migrationBuilder.CreateTable(
                name: "Salary_grant",
                columns: table => new
                {
                    Sgr_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salary_grant_id = table.Column<string>(nullable: true),
                    Salary_standard_id = table.Column<string>(nullable: true),
                    First_kind_id = table.Column<string>(nullable: true),
                    First_kind_name = table.Column<string>(nullable: true),
                    Second_kind_id = table.Column<string>(nullable: true),
                    Second_kind_name = table.Column<string>(nullable: true),
                    Third_kind_id = table.Column<string>(nullable: true),
                    Third_kind_name = table.Column<string>(nullable: true),
                    Human_amount = table.Column<int>(nullable: false),
                    Salary_standard_sum = table.Column<double>(nullable: false),
                    Salary_paid_sum = table.Column<double>(nullable: false),
                    Register = table.Column<string>(nullable: true),
                    Regist_time = table.Column<DateTime>(nullable: false),
                    Checker = table.Column<string>(nullable: true),
                    Check_time = table.Column<DateTime>(nullable: false),
                    Check_status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salary_grant", x => x.Sgr_id);
                });

            migrationBuilder.CreateTable(
                name: "Salary_grant_details",
                columns: table => new
                {
                    Grd_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salary_grant_id = table.Column<string>(nullable: true),
                    Human_id = table.Column<string>(nullable: true),
                    Human_name = table.Column<string>(nullable: true),
                    Bouns_sum = table.Column<double>(nullable: false),
                    Sale_sum = table.Column<double>(nullable: false),
                    Deduct_sum = table.Column<double>(nullable: false),
                    Salary_standard_sum = table.Column<double>(nullable: false),
                    Salary_paid_sum = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salary_grant_details", x => x.Grd_id);
                });

            migrationBuilder.CreateTable(
                name: "Salary_standard",
                columns: table => new
                {
                    Ssd_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Standard_id = table.Column<string>(nullable: true),
                    Standard_name = table.Column<string>(nullable: true),
                    Designer = table.Column<string>(nullable: true),
                    Register = table.Column<string>(nullable: true),
                    Checker = table.Column<string>(nullable: true),
                    Changer = table.Column<string>(nullable: true),
                    Regist_time = table.Column<DateTime>(nullable: false),
                    Check_time = table.Column<DateTime>(nullable: false),
                    Change_time = table.Column<DateTime>(nullable: false),
                    Salary_sum = table.Column<double>(nullable: false),
                    Check_status = table.Column<int>(nullable: false),
                    Change_status = table.Column<int>(nullable: false),
                    Check_comment = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salary_standard", x => x.Ssd_id);
                });

            migrationBuilder.CreateTable(
                name: "Salary_standard_details",
                columns: table => new
                {
                    Sdt_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Standard_id = table.Column<string>(nullable: true),
                    Standard_name = table.Column<string>(nullable: true),
                    Item_id = table.Column<int>(nullable: false),
                    Item_name = table.Column<string>(nullable: true),
                    Salary = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salary_standard_details", x => x.Sdt_id);
                });

            migrationBuilder.CreateTable(
                name: "SFquanxian",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    JUid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SFquanxian", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    Tra_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Major_kind_id = table.Column<string>(nullable: true),
                    Major_kind_name = table.Column<string>(nullable: true),
                    Major_id = table.Column<string>(nullable: true),
                    Major_name = table.Column<string>(nullable: true),
                    Human_id = table.Column<string>(nullable: true),
                    Human_name = table.Column<string>(nullable: true),
                    Training_item = table.Column<string>(nullable: true),
                    Training_time = table.Column<DateTime>(nullable: false),
                    Training_hour = table.Column<int>(nullable: false),
                    Training_degree = table.Column<string>(nullable: true),
                    Register = table.Column<string>(nullable: true),
                    Checker = table.Column<string>(nullable: true),
                    Regist_time = table.Column<DateTime>(nullable: false),
                    Check_time = table.Column<DateTime>(nullable: false),
                    Checkstatus = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Tra_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    U_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    U_name = table.Column<string>(nullable: true),
                    U_true_name = table.Column<string>(nullable: true),
                    U_password = table.Column<string>(nullable: true),
                    JueSe_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.U_id);
                });

            migrationBuilder.CreateTable(
                name: "YHquanxian",
                columns: table => new
                {
                    YHid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JueSe_id = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YHquanxian", x => x.YHid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bonus");

            migrationBuilder.DropTable(
                name: "Config_file_first_kind");

            migrationBuilder.DropTable(
                name: "Config_file_second_kind");

            migrationBuilder.DropTable(
                name: "Config_file_third_kind");

            migrationBuilder.DropTable(
                name: "Config_major");

            migrationBuilder.DropTable(
                name: "Config_major_kind");

            migrationBuilder.DropTable(
                name: "Config_primary_key");

            migrationBuilder.DropTable(
                name: "Config_public_char");

            migrationBuilder.DropTable(
                name: "Config_question_first_kind");

            migrationBuilder.DropTable(
                name: "Config_question_second_kind");

            migrationBuilder.DropTable(
                name: "Engage_answer");

            migrationBuilder.DropTable(
                name: "Engage_answer_details");

            migrationBuilder.DropTable(
                name: "Engage_exam");

            migrationBuilder.DropTable(
                name: "Engage_exam_details");

            migrationBuilder.DropTable(
                name: "Engage_interview");

            migrationBuilder.DropTable(
                name: "Engage_major_release");

            migrationBuilder.DropTable(
                name: "Engage_resume");

            migrationBuilder.DropTable(
                name: "Engage_subjects");

            migrationBuilder.DropTable(
                name: "Human_file");

            migrationBuilder.DropTable(
                name: "Human_file_dig");

            migrationBuilder.DropTable(
                name: "JueSe");

            migrationBuilder.DropTable(
                name: "Major_change");

            migrationBuilder.DropTable(
                name: "Salary_grant");

            migrationBuilder.DropTable(
                name: "Salary_grant_details");

            migrationBuilder.DropTable(
                name: "Salary_standard");

            migrationBuilder.DropTable(
                name: "Salary_standard_details");

            migrationBuilder.DropTable(
                name: "SFquanxian");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "YHquanxian");
        }
    }
}
