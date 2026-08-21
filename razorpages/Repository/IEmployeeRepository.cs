using razorpages.Models;

namespace razorpages.Repository;

public interface IEmployeeRepository
{
    IEnumerable<Employee> GetAll();
}