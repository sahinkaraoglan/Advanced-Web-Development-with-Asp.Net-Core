using razorpages.Models;

namespace razorpages.Repository;

public interface IEmployeeRepository
{
    IEnumerable<Employee> GetAll();

    Employee GetById(int id);

    Employee Update(Employee entity);
}