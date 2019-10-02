using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Model;
using System.Data.Entity;
namespace Demo.Repository
{
    public class EmployeeManagemnt : IEmployeeManagement
    {
        EmployeeContext db;
        public EmployeeManagemnt(EmployeeContext _db)
        {
            db = _db;
        }

        public async Task<int> AddEmployee(Employee Emp)
        {
            if (db != null)
            {
                await db.Employee.AddAsync(Emp);
                await db.SaveChangesAsync();

                return Emp.EmpId;
            }

            return 0;
        }

        public async Task<int> DeleteEmployee(int? EmployeeId)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var employee = await db.Employee.FirstOrDefaultAsync(x => x.EmpId == EmployeeId);

                if (employee != null)
                {
                    //Delete that post
                    db.Employee.Remove(employee);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<List<Employee>> GetEmployee()
        {
            try
            { 
            if (db != null)
            {
                return await db.Employee.ToListAsync();
            }
        }
            catch(Exception ex)
            {

            }
            return null;
        }

        public async Task<Employee> GetEmployee(int EmployeeId)
        {
            if (db != null)
            {
                return await (from p in db.Employee
                              where p.EmpId == EmployeeId
                              select new Employee
                              {
                                  EmpId = p.EmpId,
                                  EmpName = p.EmpName,
                                  Salary = p.Salary
                              }
                             ).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task UpdateEmployee(Employee emp)
        {
            if (db != null)
            {
                //Delete that post
                db.Employee.Update(emp);

                //Commit the transaction
                await db.SaveChangesAsync();
            }

        }
    }
}
