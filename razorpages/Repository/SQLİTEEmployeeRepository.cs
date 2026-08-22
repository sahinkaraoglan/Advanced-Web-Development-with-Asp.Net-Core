using razorpages.Models;
using razorpages.Repository;

namespace razorpagesExample.Repository;

public class SQLİTEEmployeeRepository : IEmployeeRepository
{
    private readonly DataContext _context;
    public SQLİTEEmployeeRepository(DataContext context)
    {
        _context = context;
    }
    public IEnumerable<Employee> GetAll()
    {
        return _context.Employees.ToList();
    }

    public Employee GetById(int id)
    {
        return _context.Employees.FirstOrDefault(i => i.Id == id);
    }

    public Employee Update(Employee entity)
    {
       var entityToUpdate = _context.Employees.FirstOrDefault(i => i.Id == entity.Id);

       if(entityToUpdate != null)
       {
            entityToUpdate.Name = entity.Name;
            entityToUpdate.Email = entity.Email;
            entityToUpdate.Deparment = entity.Deparment;
            entityToUpdate.Photo = entity.Photo;
            _context.SaveChanges();
       }
       return entityToUpdate;
    }
}