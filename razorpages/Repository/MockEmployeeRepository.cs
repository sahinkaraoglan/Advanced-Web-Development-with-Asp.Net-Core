using razorpages.Models;

namespace razorpages.Repository;

public class MockEmployeeRepository : IEmployeeRepository
{
    private List<Employee> _employeeList;
    public MockEmployeeRepository()
    {
        _employeeList = new List<Employee>()
        {
            new Employee { Id = 1, Name="Ahmet Karaoğlan", Email = "ahmetkaraoglan@gmailc.com", Photo = "1.jpg", Deparment = "Muhasebe"},
            new Employee { Id = 2, Name="Neslihan Karaoğlan", Email = "neslihankaraoglan@gmailc.com", Photo = "2.jpg", Deparment = "Muhasebe"},
            new Employee { Id = 3, Name="Sena Karaoğlan", Email = "senakaraoglan@gmailc.com", Photo = "3.jpg", Deparment = "Muhasebe"},
            new Employee { Id = 4, Name="Şahin Karaoğlan", Email = "sahinkaraoglan@gmailc.com", Photo = "4.jpg", Deparment = "Muhasebe"},
            new Employee { Id = 5, Name="Şahin Karaoğlan", Email = "sahinkaraoglan@gmailc.com", Photo = "4.jpg", Deparment = "Muhasebe"},
            new Employee { Id = 6, Name="Şahin Karaoğlan", Email = "sahinkaraoglan@gmailc.com", Photo = "4.jpg", Deparment = "Muhasebe"},
        };
    }
    public IEnumerable<Employee> GetAll()
    {
        return _employeeList;
    }

    public Employee GetById(int id)
    {
        return _employeeList.FirstOrDefault(i=> i.Id == id);
    }
}