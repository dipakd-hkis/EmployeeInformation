namespace EmployeeInfo.Services
{
    public interface IEmployeeService
    {

        IList<Employee> GetAllEmployeeDetail();

        void SaveEmployeeDetail(Employee emp);

        bool DeleteEmployeeDetail(int empId);

        bool IsUniqueCode(string employee_Code);

    }
}