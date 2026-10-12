using BoiteNuitTestDemo.BLL.Models;

namespace BoiteNuitTestDemo.BLL.Database
{
    internal class EmployeeData
    {
        private static readonly Dictionary<int, Employee> _employees = new()
        {
            { 1, new Employee("Marc",  Status.Videur,  true,  25) },
            { 2, new Employee("Sarah", Status.Barman,  true,  23) },
            { 3, new Employee("Tom",   Status.Serveur, false, 19) }
        };
    }
}