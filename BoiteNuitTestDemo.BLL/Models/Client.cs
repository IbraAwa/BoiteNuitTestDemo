namespace BoiteNuitTestDemo.BLL.Models;

public class Client
{
    public Client(string prenom, int age, string email, string password)
    {
        Prenom = prenom;
        Age = age;
        Email = email;
        Password = password;
    }

    public string Prenom { get; set; }

    public int Age { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
}
