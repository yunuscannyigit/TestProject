using TestProject.Models;

namespace TestProject.Interfaces
{
    public interface ITestRepository
    {
        Response GetParkingFee(string entry, string exit);
    }
}
