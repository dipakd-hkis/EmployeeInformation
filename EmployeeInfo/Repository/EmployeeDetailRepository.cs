using Dapper;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace EmployeeInfo.Repository
{
    public class EmployeeDetailRepository : IEmployeeDetailRepository
    {

        private IConfiguration configuration;
        public EmployeeDetailRepository(IConfiguration _configuration)
        {
            configuration = _configuration;

        }
        /// <summary>
        ///  Database connection
        /// </summary>
        /// 
        public DbConnection GetDbConnection()
        {
            string connectionstringAppSetting = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connectionstringAppSetting))
            {
                return new SqlConnection(connectionstringAppSetting);
            }
            return new SqlConnection(connectionstringAppSetting);
        }

        /// <summary>
        /// Save and Update Employee Detail
        /// </summary>
        /// 
        public void SaveEmployeeDetail(Employee emp)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@EmpId", emp.EmpId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@Employee_Code", emp.Employee_Code, DbType.String, ParameterDirection.Input);
            parameter.Add("@First_Name", emp.First_Name, DbType.String, ParameterDirection.Input);
            parameter.Add("@Last_Name", emp.Last_Name, DbType.String, ParameterDirection.Input);
            parameter.Add("@Email_Address", emp.Email_Address, DbType.String, ParameterDirection.Input);
            parameter.Add("@Address", emp.Address, DbType.String, ParameterDirection.Input);
            parameter.Add("@Phone", emp.StrPhone, DbType.String, ParameterDirection.Input);
            

            using (IDbConnection connection = GetDbConnection())
            {
                SqlMapper.Query(connection, "Add_EmployeeDetail", parameter, commandType: CommandType.StoredProcedure);
            }

        }

        /// <summary>
        /// Delete Employee
        /// </summary>
        ///
        public bool DeleteEmployeeDetail(int empId)
        {

            var parameter = new DynamicParameters();
            parameter.Add("@EmpId", empId, DbType.Int32, ParameterDirection.Input);
            using (IDbConnection connection = GetDbConnection())
            {
                var deleted = SqlMapper.Execute(connection, "DeleteEmployeeDetail", parameter, commandType: CommandType.StoredProcedure);
                if (deleted == 0)
                    return false;
                else
                    return true;
            }


        }
        /// <summary>
        ///  Check Employee Code is Unique or not
        /// </summary>
        /// 
        public bool IsUniqueCode(string employee_Code)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Employee_Code", employee_Code, DbType.String, ParameterDirection.Input);
            using (IDbConnection connection = GetDbConnection())
            {
                var IsUnique = SqlMapper.ExecuteScalar(connection, "isUniqueCode", parameter, commandType: CommandType.StoredProcedure);

                 return Convert.ToBoolean(IsUnique);
            }


        }
        /// <summary>
        ///  Get All Employee Detail
        /// </summary>
        /// 
        public IEnumerable<Employee> GetAllEmployeeDetail()
        {
            using (IDbConnection connection = GetDbConnection())
            {
                var result = connection.Query<Employee>("GetAllEmployeeDetail", commandType: CommandType.StoredProcedure);
                return result;
            }
        }        
    }
}

