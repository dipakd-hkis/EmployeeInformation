

namespace EmployeeInfo.Repository
{
    public interface IEmployeeDetailRepository
    {
        IEnumerable<Employee> GetAllEmployeeDetail();

        void SaveEmployeeDetail(Employee emp);

        bool DeleteEmployeeDetail(int empId);

        bool IsUniqueCode(string employee_Code);

    }
}