using BoiteNuitTestDemo.BLL.Models;

namespace BoiteNuitTestDemo.BLL.Database
{
    internal class EmployeeData
    {
        private static int _nextId = 4;

        private static readonly Dictionary<int, Employee> _employees = new()
        {
            { 1, new Employee { prenom = "Marc",  status = Status.Videur,  haveDiplome = true,  age = 25 } },
            { 2, new Employee { prenom = "Sarah", status = Status.Barman,  haveDiplome = true,  age = 23 } },
            { 3, new Employee { prenom = "Tom",   status = Status.Serveur, haveDiplome = false, age = 19 } }
        };

        public IEnumerable<Employee> GetAll() => _employees.Values;

        public Employee? GetById(int id) =>
            _employees.TryGetValue(id, out var employee) ? employee : null;

        public int Add(Employee employee)
        {
            int id = _nextId++;
            _employees.Add(id, employee);
            return id;
        }

        public bool Delete(int id) => _employees.Remove(id);
    }
}