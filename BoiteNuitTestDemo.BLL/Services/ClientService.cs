using BoiteNuitTestDemo.BLL.Database;
using BoiteNuitTestDemo.BLL.Errors;
using BoiteNuitTestDemo.BLL.Models;

namespace BoiteNuitTestDemo.BLL.Services;

public class ClientService
{
    public Client Create(string prenom, int age, string email, string password)
    {
        Client? clientDb = ClientData.Clients.Values.SingleOrDefault(
            client => client.Email == email);

        if (clientDb is not null)
        {
            throw new Exception(ErrorName.EmailAlreadyExist);
        }

        // EXERCICE : écrire une condition qui vérifie que le client a au moins 16 ans.
        // Si ce n'est pas le cas, lancer une ArgumentException
        // avec le message d'erreur ajouté dans ErrorName.

        return new Client(prenom, age, email, password);
    }
}