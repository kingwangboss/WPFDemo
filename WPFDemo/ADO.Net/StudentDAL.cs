using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Net
{
    class StudentDAL
    {
        /// <summary>
        /// 获取数据总条数
        /// </summary>
        /// <returns></returns>
        public static int getCount()
        {
            return (int)SqlHelper.ExecuteScalar("select count(*) from Student");
        }

        public static int DeleteById(int id)
        {
            return SqlHelper.ExecuteNonQuery("delete from Student where Stu_id = @Stu_id", new SqlParameter("@Stu_id", id));
        }
    }
}
