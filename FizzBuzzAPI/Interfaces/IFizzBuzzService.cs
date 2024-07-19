using FizzBuzzAPI.Models;

namespace FizzBuzzAPI.Interfaces
{
    public interface IFizzBuzzService
    {
        FizzBuzzResult ProcessValue(string value);
    }
}