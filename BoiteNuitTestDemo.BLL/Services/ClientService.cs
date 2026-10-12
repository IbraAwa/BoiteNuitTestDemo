using BoiteNuitTestDemo.BLL.Database;
using BoiteNuitTestDemo.BLL.Errors;
using BoiteNuitTestDemo.BLL.Models;
using BoiteNuitTestDemo.BLL.Validators;

namespace BoiteNuitTestDemo.BLL.Services;

public class ClientService
{
    private readonly IClientValidator _clientValidator;

    public ClientService(IClientValidator clientValidator)
    {
        _clientValidator = clientValidator;
    }

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
        // avec le message d'erreur ajouté dans ErrorName
        
        if(age < 16)
        {
            throw new ArgumentException(ErrorName.AgeIsUnder16);
        }

        // Password doit être plus grand que 4 caractère et au moin une majuscule
        // count pour compter les caractère
        // any avec char.isUpper()
        // Datannotation theory


        return new Client(prenom, age, email, password);
    }

    public void Update(int id, string prenom, int age, string email, string password)
    {
        Client? clientInChange = null;
        bool isExistingClient = ClientData.Clients.TryGetValue(id, out clientInChange);

        if(!isExistingClient)
        {
            throw new ArgumentNullException("l'id de la personne n'existe pas");
        }

        if(!_clientValidator.isEmailUnique(email))
        {
            throw new Exception(ErrorName.EmailAlreadyExist);
        }

        // Appeler mon validator.isAgeValid()
        // faire sa condition
        // TESTER SI ON RENVOIE BIEN UNE EXCEPTION AVEC SON MESSAGE ERREUR

        //Appeler mon validator.isPasswordValid()
        //faire sa condition
        // TESTER SI ON RENVOIE BIEN UNE EXCEPTION AVEC SON MESSAGE ERREUR


    }
    
}