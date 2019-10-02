using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Model;
namespace Demo.Repository
{
    public interface IEmployeeManagement
    {
           Task<List<Employee>> GetEmployee();
        Task<Employee> GetEmployee(int  EmployeeId);
        //Task<List<PostViewModel>> GetPosts();

        //Task<PostViewModel> GetPost(int? postId);

        Task<int> AddEmployee(Employee Emp);

        Task<int> DeleteEmployee(int? EmployeeId);

        Task UpdateEmployee(Employee Emp);
    }
}
