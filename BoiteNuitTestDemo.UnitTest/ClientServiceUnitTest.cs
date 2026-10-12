using BoiteNuitTestDemo.BLL.Errors;
using BoiteNuitTestDemo.BLL.Models;
using BoiteNuitTestDemo.BLL.Services;

namespace BoiteNuitTestDemo.UnitTest
{

    // TESTER QUAND JE RENTRE UN EMAIL QUI NEXISTE PAS DANS DB IL RENVOIE CLIENT
    // TESTER QUAND JE RENTRE UN EMAIL QUI EXISTE DANS DB IL THROW EXCEPTION
    public class ClientServiceUnitTest
    {
        // Permet de dire notre méthode en-dessous est un test
        // insère dans l'explorateur de test la méthode
        // Arborescence
        // Nom class > nom méthode


        // nom méthode convention :
        // NomMéthodeAppeler_WhenContext_CeQuilDevraitRetournerOuLancer
        // Create_WhenEmailExistInDb_ShouldThrowException
        [Fact] 
        public void Create_WhenEmailExistInDb_ShouldThrowException()
        {
            // AAA
            // ARRANGE
            // préparer variables/données et objet qui sert à notre test
            ClientService clientService = new();
            string prenom = "Test";
            int age = 18;
            // on cherche email dans la DB
            // MAIS ATTENTION EN REEL
            // ON CREE UNE FAKE DB IN MEMORY 
            string email = "lucas@gmail.com";
            string password = "Test123";


            // ACT
            Exception? exception = Assert.Throws<Exception>(() => clientService.Create(prenom, age, email, password));

            // ASSERT

            Assert.NotNull(exception);
            Assert.Equal(ErrorName.EmailAlreadyExist, exception.Message);
        }

        [Fact]
        public void Create_WhenEmailNotExistInDb_ShouldReturnClient()
        {
            // AAA (Triple A)
            // ARRANGE
            string prenom = "test";
            int age = 18;
            string email = "test@hotmail.fr";
            string password = "Test123*";
            ClientService clientService = new ClientService();

            Client ClientExpected = new Client(prenom, age, email, password);
            // ACT
            Client clientTest = clientService.Create(prenom, age, email, password);

            // ASSERT
            Assert.NotNull(clientTest);
            Assert.Equal(ClientExpected.Prenom, clientTest.Prenom);
            Assert.Equal(ClientExpected.Age, clientTest.Age);
            Assert.Equal(ClientExpected.Email, clientTest.Email);
            Assert.Equal(ClientExpected.Password, clientTest.Password);

            // Test automatiquement faux car age en int et email en string
            //Assert.Equal(ClientExpected.Age, clientTest.Email);
        }

        [Fact]
        // DISCLAIMER : ARRANGE DOIT S'ADAPTER AU CHANGEMENT DANS METHODE CREATE CAR
        // ON TEST QUAND TOUT FONCTIONNE SI LE CLIENT RETOURNER EST BIEN CELUI PASSER EN PARAMETRE
        // DONC TOUTE EXCEPTION DOIT ETRE EVITER
        // POURQUOI CE TEST ? :
        // TESTER UNE SEUL FOIS SI SA RETOURNE BIEN UN CLIENT
        public void Create_WhenEverythingGood_ShouldReturnClient()
        {
            // AAA (Triple A)
            // ARRANGE
            string prenom = "test";
            int age = 18;
            string email = "test@hotmail.fr";
            string password = "Test123*";
            ClientService clientService = new ClientService();

            Client ClientExpected = new Client(prenom, age, email, password);
            // ACT
            Client clientTest = clientService.Create(prenom, age, email, password);

            // ASSERT
            Assert.NotNull(clientTest);
            Assert.Equal(ClientExpected.Prenom, clientTest.Prenom);
            Assert.Equal(ClientExpected.Age, clientTest.Age);
            Assert.Equal(ClientExpected.Email, clientTest.Email);
            Assert.Equal(ClientExpected.Password, clientTest.Password);

            // Test automatiquement faux car age en int et email en string
            //Assert.Equal(ClientExpected.Age, clientTest.Email);
        }

        // TEST CONCERNANT LAGE QUI DOIT ETRE STRICTEMENT PLUS DE 16ANS
        // DANS  service crée la condition d'abord
        // condition si strictement - que 16 ans doit renvoyer argument null exception
        // avec message suivant "Your client is too young because under 16 years old"
        // SI AGE - que 16ans throw exception
        // SI AGE = 16ans should return client
        // SI AGE + 16ans should return client
    }
}
