using Backend.Models;
using System.Net;

namespace Backend.Repo.RepoInterface
{
    public interface IEmployeeRepo
    {
        public List<Employee> GetAll();
        public Employee GetById(int id);
        public HttpStatusCode Add(Employee employee);
        public HttpStatusCode Delete(int id);
        public HttpStatusCode Update(EmployeeUpdate employee);
    }
}
