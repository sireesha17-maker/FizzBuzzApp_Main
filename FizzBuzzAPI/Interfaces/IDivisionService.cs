using FizzBuzzAPI.Interfaces;
using FizzBuzzAPI.Models;

namespace FizzBuzzAPI.Interfaces
{
    public interface IDivisionService
    {
        bool IsDivisible(int number);
        string DivisionMessage(int number);
    }
}



