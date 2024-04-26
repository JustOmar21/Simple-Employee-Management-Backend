using Backend.Models;
using Backend.Repo.RepoInterface;
using System.Net;

namespace Backend.Repo.RepoImplementation
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly EmpContext context;
        public EmployeeRepo(EmpContext context)
        {
            this.context = context;
        }
        public HttpStatusCode Add(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return HttpStatusCode.Created;
        }

        public HttpStatusCode Delete(int id)
        {
            var emp = GetById(id);
            context.Employees.Remove(emp);
            context.SaveChanges();
            return HttpStatusCode.NoContent;
        }

        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return context.Employees.Find(id) ?? throw new KeyNotFoundException("");
        }

        public HttpStatusCode Update(EmployeeUpdate employee)
        {
            var emp = GetById(employee.Id) ;
            emp.Name = employee.Name;
            emp.Notes = employee.Notes;
            emp.Role = employee.Role;
            emp.Is1stAppointment = employee.Is1stAppointment;
            emp.Gender = employee.Gender;
            context.SaveChanges();
            return HttpStatusCode.NoContent;
        }
    }
}
