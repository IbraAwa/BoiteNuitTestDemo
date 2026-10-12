using BoiteNuitTestDemo.BLL.Errors;
using BoiteNuitTestDemo.BLL.Models;
using BoiteNuitTestDemo.BLL.Services;
using BoiteNuitTestDemo.BLL.Validators;
using Moq;

namespace BoiteNuitTestDemo.UnitTest
{
    public class ClientServiceUnitTest
    {
        private readonly Mock<IClientValidator> _MockValidator;

        public ClientServiceUnitTest()
        {
            _MockValidator = new Mock<IClientValidator>();
        }

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
            // MOCK DUMMY
            // car juste pour que l'objet clientService compile
            ClientService clientService = new(_MockValidator.Object); // MOCK DUMMY
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
            ClientService clientService = new ClientService(_MockValidator.Object);

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
        // condition si strictement - que 16 ans doit renvoyer argument exception
        // avec message suivant "Your client is too young because under 16 years old"
        // SI AGE - que 16ans throw exception
        // SI AGE = 16ans should return client
        // SI AGE + 16ans should return client

        [Theory] // Comme le fact mais vous permet qu'une seul méthode peut tester plusieurs cas différents
        // un InlinData = un test case
        [InlineData(15)]
        //a l'intérieur on respecte l'ordre des parametre et son type car il va s'affecter dans le parametre de la méthode
        [InlineData(-15)] // -> Create_WhenAgeIsUnder16_ShouldThrowArgumentException(-15)
        public void Create_WhenAgeIsUnder16_ShouldThrowArgumentException(int ageTest)
        {
            // TRIPLE AAA (ARRANGE, ACT, ASSERT)
            // ARRANGE
            string prenom = "test";
            int age = ageTest;
            string email = "ageIsUnder16@hotmail.fr";
            string password = "Test123*";
            ClientService clientService = new(_MockValidator.Object);

            // ACT
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                clientService.Create(prenom, age, email, password));

            // ASSERT
            Assert.Equal(ErrorName.AgeIsUnder16, exception.Message);
        }

        // UPDATE ----------------------

        [Fact]
        public void Update_WhenEmailAlreadyExistInDb_ShouldThrowException()
        {
            /// TRIPLE AAA (ARRANGE / ACT / ASSERT)
            /// ARRANGE

            int id = 1;
            string prenom = "nouveau";
            int age = 18;
            string email = "nathan@gmail.com";
            string password = "Test123";
            ClientService clientService = new(_MockValidator.Object);

            // J'appel mon isEmailUnique en bypassant la logique à l'intérieur
            // Et lui demande un return dont j'ai besoin pour mon test
            // dans ce cas qu'il renvoie false car ça veut dire que l'email est déjà dans la DB
            _MockValidator.Setup(validator => validator.isEmailUnique(email))
                .Returns(false);

            // ACT
            Exception exception = Assert.Throws<Exception>(() =>
                clientService.Update(id, prenom, age, email, password));

            // ASSERT

            Assert.Equal(ErrorName.EmailAlreadyExist, exception.Message);
          


        }
    }
}
