using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bai1.Model;

namespace Bai1.DAO
{
    class EmployeeDAO
    {
        SqlConnection conn;

        public void Connect()
        {
            string strconnect = @"Data Source=DESKTOP-1GG0LVP\SQLEXPRESS;Initial Catalog=HoTenDB;Integrated Security=True";
            conn = new SqlConnection(strconnect);
            conn.Open();
        }
        public void CloseConnect()
        {
            conn.Close();
        }

        public void AddEmployee(ModelEmployee employee)
        {
            Connect();
            string insert = "insert into Employee( Name, Address, Department,Gender,EmployeeType) values(@EmployeeId, @Name, @Department, @Gender, @EmployeeType)";
            SqlCommand cmd = new SqlCommand(insert, conn);
            //cmd.Parameters.Add(new SqlParameter("@EmployeeId", employee.EmployeeId));
            cmd.Parameters.Add(new SqlParameter("@Name", employee.Name));
            cmd.Parameters.Add(new SqlParameter("@Department", employee.Department));
            cmd.Parameters.Add(new SqlParameter("@Gender", employee.Gender));
            cmd.Parameters.Add(new SqlParameter("@EmployeeType", employee.EmployeeType));
            cmd.ExecuteNonQuery();
            CloseConnect();
        }
        public void  DelEmployee(string Id)
        {
            Connect();
            string delete = "Delete form Employee where EmployeeId = @Id";
            SqlCommand cmd = new SqlCommand(delete, conn);
            cmd.Parameters.Add(new SqlParameter("@EmployeeId", Id));
            CloseConnect();
        }
    }
}
