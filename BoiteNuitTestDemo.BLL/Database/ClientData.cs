using BoiteNuitTestDemo.BLL.Models;

namespace BoiteNuitTestDemo.BLL.Database;

public static class ClientData
{
    public static readonly IDictionary<int, Client> Clients = new Dictionary<int, Client>
    {
        { 1, new Client("Lucas", 22, "lucas@gmail.com", "Lucas123!") },
        { 2, new Client("Emma", 25, "emma@gmail.com", "Emma123!") },
        { 3, new Client("Nathan", 30, "nathan@gmail.com", "Nathan123!") },
        { 4, new Client("Chloe", 21, "chloe@gmail.com", "Chloe123!") },
        { 5, new Client("Hugo", 28, "hugo@gmail.com", "Hugo123!") }
    };
}