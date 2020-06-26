using albama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace albama.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employees = new List<Employee>();

        public EmployeeService()
        {
            _employees.Add(new Employee
            {
                Id = 1,
                DepartmentId =1,
                FristName ="Nick",
                LastName = "Carter",
                Gender = Gender.男
            });
            _employees.Add(new Employee
            {
                Id = 2,
                DepartmentId = 1,
                FristName = "Kite",
                LastName = "wind",
                Gender = Gender.女
            });
            _employees.Add(new Employee
            {
                Id = 3,
                DepartmentId = 1,
                FristName = "Nick",
                LastName = "Carter",
                Gender = Gender.男
            });
            _employees.Add(new Employee
            {
                Id = 4,
                DepartmentId = 1,
                FristName = "li",
                LastName = "mei",
                Gender = Gender.男
            });
            _employees.Add(new Employee
            {
                Id = 5,
                DepartmentId = 1,
                FristName = "Ham",
                LastName = "MeiMei",
                Gender = Gender.女
            });
            _employees.Add(new Employee
            {
                Id = 6,
                DepartmentId = 2,
                FristName = "jack",
                LastName = "jone",
                Gender = Gender.男
            });
            _employees.Add(new Employee
            {
                Id = 7,
                DepartmentId = 1,
                FristName = "jc",
                LastName = "amni",
                Gender = Gender.男
            });
            _employees.Add(new Employee
            {
                Id = 8,
                DepartmentId = 1,
                FristName = "AC",
                LastName = "Denken",
                Gender = Gender.男
            });
            _employees.Add(new Employee
            {
                Id = 9,
                DepartmentId = 1,
                FristName = "li",
                LastName = "qiqiu",
                Gender = Gender.男
            });
        }

        public Task add(Employee employee)
        {
            employee.Id = _employees.Max(x => x.Id) + 1;
            _employees.Add(employee);
            return Task.CompletedTask;
        }

        public Task<Employee> Frie(int id)
        {
            return Task.Run(() =>
            {
                var employee = _employees.FirstOrDefault(x => x.Id == id);
                if (employee != null)
                {
                    employee.Fried = true;
                    return employee;
                }
                return null;
            });
        }

        public Task<IEnumerable<Employee>> GetByDepartMentId(int departmentId)
        {
            return Task.Run(() => _employees.Where(p=>p.DepartmentId == departmentId));
        }
    }
}
