using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADOsanceng.Model;

namespace ADOsanceng.DAL
{
    class CustomerDAL
    {
        //根据Id获取GetById,Update,DeleteById,GetAll,GetPagedData(分页数据)
        //Insert(插入数据)

        private static Customer ToCustomer(DataRow row)
        {
            Customer customer = new Customer();
            customer.Id = (int)row["id"];
            customer.Name = (string)row["Name"];
            customer.Address = (string)row["Adress"];
            customer.BirthDay = (DateTime?)SqlHelper.FromDbValue(row["BirthDay"]);
            customer.TelNum = (string)row["TelNum"];
            customer.CustomerLevel = (string)row["CustomerLevel"];
            return customer;
        }

        public static Customer GetById(int id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from Customer where id = @id", new SqlParameter("@id", id));
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else if (dt.Rows.Count > 1)
            {
                throw new Exception("查出多条数据");
            }
            else
            {
                DataRow row = dt.Rows[0];
                return ToCustomer(row);
            }
        }

        public void DeleteById(int id)
        {
            SqlHelper.ExecuteNonQuery("delete from Customer where id = @id", new SqlParameter("@id", id));
        }

        public void Insert(Customer customer)
        {
            SqlHelper.ExecuteNonQuery(@"INSERT INTO [Customer]
           ([Name],[BirthDay],[Address],[TelNum],[CustomerLevel]) VALUES
           (@Name,@BirthDay,@Address,@TelNum,@CustomerLevel)",
           new SqlParameter("@Name",customer.Name),
           new SqlParameter("@BirthDay", SqlHelper.ToDbValue(customer.BirthDay)),
           new SqlParameter("@Address", customer.Address),
           new SqlParameter("@TelNum", customer.TelNum),
           new SqlParameter("@CustomerLevel", customer.CustomerLevel));
        }

        public void Update(Customer customer)
        {
            SqlHelper.ExecuteNonQuery(@"UPDATE [Customer]SET[Name] = 
@Name,[BirthDay] = @BirthDay,[Address] = @Address,[TelNum] =  @TelNum,[CustomerLevel] = @CustomerLevel WHERE id=@id",
           new SqlParameter("@Name", customer.Name),
           new SqlParameter("@BirthDay", SqlHelper.ToDbValue(customer.BirthDay)),
           new SqlParameter("@Address", customer.Address),
           new SqlParameter("@TelNum", customer.TelNum),
           new SqlParameter("@CustomerLevel", customer.CustomerLevel));
        }

        public Customer[] GetAll()
        {
            DataTable table = SqlHelper.ExecuteDataTable("select * from Customer");
            Customer[] customers = new Customer[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                
                customers[i] = ToCustomer(row);
            }
            return customers;
        }
    }
}
