using RefundManagementBL.Exceptions.EmployeeExceptions;
using RefundManagementBL.Exceptions.GeneralExceptions;
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

        public int AddEmployee(Employee employee)
        {
            var result = _employeeRepository.Add(employee);

            if (result != null)
            {
                return result.EmployeeId;
            }
            throw new DuplicateEmployeeException();
        }

        public bool CanAuthorizeExpense(int employeeId)
        {
            var employee = _employeeRepository.Get(employeeId);
            if (employee != null)
            {
                return employee.GetExpenseAccess();
            }
            throw new AccessDeniedException();
        }

        public Employee DeleteEmployeeByID(int employeeId)
        {
            var employee = _employeeRepository.Get(employeeId);
            if (employee != null)
            {
                _employeeRepository.Delete(employeeId);
            }
            throw new EmployeeNotFoundException();
        }

        public List<Employee> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAll();
            if (employees != null)
            {
                return new List<Employee>(employees);
            }
            throw new NoDataAvailableException();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            var employee = _employeeRepository.Get(employeeId);
            if (employee != null)
            {
                return employee;
            }
            throw new EmployeeNotFoundException();
        }

        public string GetEmployeeDepartment(int employeeId)
        {
            var employee = _employeeRepository.Get(employeeId);
            if (employee != null)
            {
                return employee.Department;
            }
            throw new EmployeeNotFoundException();
        }

        public string GetEmployeeName(int employeeId)
        {
            var employee = _employeeRepository.Get(employeeId);
            if (employee != null)
            {
                return employee.Name;
            }
            throw new EmployeeNotFoundException();
        }

        public Employee UpdateEmployeeName(string EmployeeNewName, int employeeId)
        {
            var employee = _employeeRepository.Get(employeeId);
            if (employee != null)
            {
             employee.Name = EmployeeNewName;
             _employeeRepository.Update(employee);
             return employee;
            }
            throw new EmployeeNotFoundException();
        }

        public Employee UpdateEmployeeSalaryById(int employeeId, double NewSalary)
        {
            var employee = _employeeRepository.Get(employeeId);
            if (employee != null)
            {
                employee.Salary = NewSalary;
                _employeeRepository.Update(employee);
                return employee;
            }
            throw new EmployeeNotFoundException();
        }
    }
}
