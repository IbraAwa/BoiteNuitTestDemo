using BoiteNuitTestDemo.BLL.Validators;

namespace BoiteNuitTestDemo.UnitTest;

public class EmployeeValidatorUnitTest
{
    [Theory]
    [InlineData(false, 17)]
    [InlineData(true, 17)]
    [InlineData(false, 19)]
    public void IsValidVideur_WhenVideurIsNotValid_ShouldReturnFalse(bool haveDiplome, int age)
    {
        // ARRANGE
        EmployeeValidator employeeValidator = new EmployeeValidator();

        // ACT
        bool? isValid = employeeValidator.IsValidVideur(haveDiplome, age);

        // ASSERT
        Assert.NotNull(isValid); // conceptuellement il ne sert a rien 
        Assert.Equal(expected: false, actual: isValid); 
    }
}
