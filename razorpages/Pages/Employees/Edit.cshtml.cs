using Microsoft.AspNetCore.Mvc.RazorPages;
using razorpages.Models;
using razorpages.Repository;

namespace razorpages.Pages.Employees;

public class EditModel : PageModel
{
    private readonly IEmployeeRepository _employeeRepository;
    public EditModel(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    public Employee Employee { get; set; } = null!;
    public void OnGet(int id)
    {
        Employee = _employeeRepository.GetById(id);
    }
}