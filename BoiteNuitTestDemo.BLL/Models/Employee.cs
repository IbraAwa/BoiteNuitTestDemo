namespace BoiteNuitTestDemo.BLL.Models;

public class Employee
{
    public Employee(string prenom, Status status, bool haveDiplome, int age)
    {
        Prenom = prenom;
        Status = status;
        HaveDiplome = haveDiplome;
        Age = age;
    }

    public string Prenom { get; set; }
    public Status Status { get; set; }
    public bool HaveDiplome { get; set; }
    public int Age { get; set; }
}


// USER STORY
// En tant que gérant du club,
// je veux créer un employé
// afin de constituer mon équipe.
//
// Critères d'acceptation (règles métier) :
// - Un videur doit avoir un diplôme et au moins 18 ans
// - Un barman doit avoir un diplôme et au moins 21 ans
// - Un serveur doit avoir au moins 18 ans (diplôme non requis)
// - Si une règle n'est pas respectée, l'employé n'est pas créé et une erreur est renvoyée

// MÉTHODE TDD : cycle Red → Green → Refactor, un test à la fois
// Crée la classe EmployeeServiceUnitTest dans le projet BoiteNuitTestDemo.UnitTest
// 1. RED      : écrire UN test qui échoue (ne pas compiler compte comme un échec)
// 2. GREEN    : écrire le code minimum pour que ce test passe
// 3. REFACTOR : améliorer le code sans casser les tests
// 4. Recommencer avec le test suivant
// EmployeeService et IEmployeeValidator sont créés au fil des tests, pas avant.