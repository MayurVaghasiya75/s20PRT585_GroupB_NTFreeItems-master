using System;
namespace EmployeeManagementAngularSpaApplication.Models
{
    public class Employee
    {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public string Department { get; set; }
    public string City { get; set; }
    public string Salary { get; set; }
    public int isActive { get;  set; }
    public int isRetired { get; set; }
    }
}
