using RefundManagementDAL;
using RefundManagementModelLibrary;

namespace RefundManagementBL
{
    public class EmployeeBL : IEmployeeServices
    {
        readonly IRepository<int, Employee> _employeeRepository;
        public EmployeeBL()
        {
            _employeeRepository = new EmployeeRepository();
        }
    }
}
