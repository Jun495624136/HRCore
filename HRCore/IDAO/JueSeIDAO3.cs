﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace IDAO
{
    public interface JueSeIDAO3
    {
        DBFenYe<JueSeModel> Fenye(int dqy, string tablename, string where, string keyname, int pagesize);
        Task<List<JueSeModel>> RoleSelect();
        Task<int> ADD(JueSeModel bjm);
        Task<int> Delete(int id);
        Task<JueSeModel> select(int id);
    }
}
