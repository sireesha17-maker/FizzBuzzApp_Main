using FizzBuzzAPI.Interfaces;

namespace FizzBuzzAPI.Services
{
    public class DivisionByThreeService : IDivisionService
    {
        public bool IsDivisible(int number) => number % 3 == 0;

        public string DivisionMessage(int number) => $"Divided {number} by 3";
    }
}
