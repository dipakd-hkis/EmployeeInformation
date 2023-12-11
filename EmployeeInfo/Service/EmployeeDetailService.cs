using EmployeeInfo.Repository;

namespace EmployeeInfo.Services
{
    public class EmployeeService : IEmployeeService
    {
        public readonly IEmployeeDetailRepository _employeeDetailRepository;
        public EmployeeService(IEmployeeDetailRepository employeeDetailRepository)
        {
            _employeeDetailRepository = employeeDetailRepository;
        }


        /// <summary>
        ///  Get All Employee Detail
        /// </summary>
        /// 

        public IList<Employee> GetAllEmployeeDetail()
        {
            IList<Employee> emplist= new List<Employee>();
             var list = _employeeDetailRepository.GetAllEmployeeDetail();
            foreach (var emp in list)
            {
                Employee employee = new Employee();
                employee.EmpId = emp.EmpId;
                employee.First_Name = emp.First_Name;
                employee.Last_Name = emp.Last_Name;
                employee.Employee_Code = emp.Employee_Code;
                employee.Address = emp.Address;
                employee.Email_Address = emp.Email_Address;
                employee.Phone = emp.StrPhone.ToString().Split(',').ToList();
                employee.StrPhone = emp.StrPhone;
                emplist.Add(employee);
            }
            return emplist;
        }

        /// <summary>
        ///  Save Employee Detail
        /// </summary>
        /// <param name="emp"></param>
        public void SaveEmployeeDetail(Employee emp)
        {
            emp.StrPhone = string.Join(",", emp.Phone);
            _employeeDetailRepository.SaveEmployeeDetail(emp);
        }

        /// <summary>
        /// Delete Employee detail
        /// </summary>
        /// <param name="EmpId"></param>
        /// <returns></returns>
        public bool DeleteEmployeeDetail(int empId)
        {
            bool deleted = _employeeDetailRepository.DeleteEmployeeDetail(empId);
            return deleted;
        }

        /// <summary>
        /// get IS Unique Code
        /// </summary>
        /// <param name="Employee_Code"></param>
        public bool IsUniqueCode(string employee_Code)
        {
            return _employeeDetailRepository.IsUniqueCode(employee_Code);
        }
        
        
        
    }
}
