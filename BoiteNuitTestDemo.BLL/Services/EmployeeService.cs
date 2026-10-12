using BoiteNuitTestDemo.BLL.Errors;
using BoiteNuitTestDemo.BLL.Models;
using BoiteNuitTestDemo.BLL.Validators;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BoiteNuitTestDemo.BLL.Services;

public class EmployeeService
{
    private readonly IEmployeeValidator _employeeValidator;

    public EmployeeService(IEmployeeValidator employeeValidator)
    {
        _employeeValidator = employeeValidator;
    }

    public void Create(string prenom, Status status, bool haveDiplome, int age)
    {
        if(!_employeeValidator.IsValidVideur(haveDiplome, age))
        {
            throw new ArgumentException(ErrorName.VideurNotValid);
        }
    }
}
