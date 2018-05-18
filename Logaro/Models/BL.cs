using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Logaro.Models
{
    public class BL
    {
        //SqlHelper sql1 = new SqlHelper();

        //public List<Logaro> logaroListBind()
        //{
        //    DataTable dt = new DataTable();
        //    SqlParameter[] GetBalance_Parm = new SqlParameter[]
        //    {

        //    };
        //    DataSet _DS = SqlHelper.GetDataSet(SqlHelper.mainConnectionString, CommandType.StoredProcedure, "[GetStdInfo]", GetBalance_Parm);
        //    List<student> lst = new List<student>();
        //    if (_DS.Tables[0].Rows.Count > 0)
        //    {
        //        foreach (DataRow item in _DS.Tables[0].Rows)
        //        {
        //            lst.Add(new student
        //            {
        //                Id = Convert.ToInt32(item["id"]),
        //                Name = Convert.ToString(item["name"]),
        //                Fathername = Convert.ToString(item["fathername"]),
        //                Mothername = Convert.ToString(item["mothername"]),
        //                Age = Convert.ToInt32(item["age"]),
        //                Country = Convert.ToString(item["country"]),
        //                State = Convert.ToString(item["state"]),
        //                Nationality = Convert.ToString(item["nationality"])

        //            });
        //        }

        //    }
        //    return lst;
        //}
    }
}