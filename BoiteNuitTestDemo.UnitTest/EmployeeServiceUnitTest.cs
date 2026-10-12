using BoiteNuitTestDemo.BLL.Errors;
using BoiteNuitTestDemo.BLL.Models;
using BoiteNuitTestDemo.BLL.Services;
using BoiteNuitTestDemo.BLL.Validators;
using Moq;

namespace BoiteNuitTestDemo.UnitTest;

public class EmployeeServiceUnitTest
{
    private readonly Mock<IEmployeeValidator> _mockValidator;

    public EmployeeServiceUnitTest()
    {
            _mockValidator = new Mock<IEmployeeValidator>();
    }
    // - Un videur doit avoir un diplôme et au moins 18 ans
    //  public Employee(string prenom, Status status, bool haveDiplome, int age)
    [Fact]
    public void Create_WhenVideurNotValid_ShouldReturnThrowArgumentException()
    {
        // ARRANGE
        string prenom = "salut";
        Status status = Status.Videur;
        EmployeeService employeeService = new EmployeeService(_mockValidator.Object);
        _mockValidator.Setup(x => x.IsValidVideur(It.IsAny<bool>(), It.IsAny<int>())).Returns(false);

        // ACT
        ArgumentException exception = Assert.Throws<ArgumentException>(() =>
              employeeService.Create(prenom, status, true, 16));

        // ASSERT
        Assert.Equal(ErrorName.VideurNotValid, exception.Message);

    }
}
