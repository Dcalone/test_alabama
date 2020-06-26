using albama.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace albama.Services
{
    public interface IEmployeeService
    {
        Task add(Employee employee);

        Task<IEnumerable<Employee>> GetByDepartMentId(int departmentId);

        Task<Employee> Frie(int id);
    }
}
