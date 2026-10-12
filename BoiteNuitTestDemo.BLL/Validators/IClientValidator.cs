using BoiteNuitTestDemo.BLL.Database;
using BoiteNuitTestDemo.BLL.Models;

namespace BoiteNuitTestDemo.BLL.Validators;

public interface IClientValidator
{
    public bool isEmailUnique(string email); // SI TRUE => Email unique par contre si FALSE => Email doublon

    public bool isAgeValid(int age);

    public bool isPasswordValid(string password);
}


public class ClientValidator : IClientValidator
{
    public bool isAgeValid(int age)
    {
        return age >= 16; // TRUE SI AGE PLUS GRAND OU EGALE A 16
    }

    public bool isEmailUnique(string email)
    {
        Client? clientDb = ClientData.Clients.Values.SingleOrDefault
            (client => client.Email == email);

        return clientDb is null ? true : false;
    }

    public bool isPasswordValid(string password)
    {
        if (password.Length > 4 && password.Any(c => char.IsUpper(c)))
        {
            return true;
        }

        return false;
    }
}