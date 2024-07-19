using FizzBuzzAPI.Interfaces;

namespace FizzBuzzAPI.Services
{
    public class DivisionByFiveService : IDivisionService
    {
        public bool IsDivisible(int number) => number % 5 == 0;

        public string DivisionMessage(int number) => $"Divided {number} by 5";
    }
}
