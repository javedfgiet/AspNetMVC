using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class EmployeeBusinessLayer
    {
        public IEnumerable<Employee> Employees
        {
            get
            {
                string conStr = ConfigurationManager
                    .ConnectionStrings["DBCS"].ConnectionString;
                List<Employee> employees = new List<Employee>();

                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Employee emp = new Employee();
                        emp.ID = Convert.ToInt32(rdr["ID"]);
                        emp.Name = rdr["Name"].ToString();
                        emp.Gender = rdr["Gender"].ToString();
                        emp.City = rdr["City"].ToString();

                        if (!(rdr["DatOfBirth"] is DBNull))
                        {
                            emp.DateOfBirth = Convert.ToDateTime(rdr["DatOfBirth"]);
                        }

                        employees.Add(emp);
                    }
                }
                return employees;
            }
        }

        public void AddEmployee(Employee emp)
        {
            string conStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = emp.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = emp.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paraCity = new SqlParameter();
                paraCity.ParameterName = "@City";
                paraCity.Value = emp.City;
                cmd.Parameters.Add(paraCity);

                SqlParameter paramDOB = new SqlParameter();
                paramDOB.ParameterName = "@DateOfBirth";
                paramDOB.Value = emp.DateOfBirth;
                cmd.Parameters.Add(paramDOB);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
