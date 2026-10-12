namespace BoiteNuitTestDemo.BLL.Validators;

public interface IEmployeeValidator
{
    public bool IsValidVideur(bool haveDiplome, int age);
}

public class EmployeeValidator : IEmployeeValidator
{
    public bool IsValidVideur(bool haveDiplome, int age)
    {
        if(haveDiplome && age >= 18)
        {
            return true;
        }

        return false;
    }
}

