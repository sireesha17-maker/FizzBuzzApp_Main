using FizzBuzzAPI.Interfaces;
using FizzBuzzAPI.Models;

namespace FizzBuzzAPI.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
        private readonly IDivisionService _divisionByThreeService;
        private readonly IDivisionService _divisionByFiveService;

        public FizzBuzzService(IDivisionService divisionByThreeService, IDivisionService divisionByFiveService)
        {
            _divisionByThreeService = divisionByThreeService;
            _divisionByFiveService = divisionByFiveService;
        }

        public FizzBuzzResult ProcessValue(string value)
        {
            var result = new FizzBuzzResult { Input = value };

            if (int.TryParse(value, out int number))
            {
                if (_divisionByThreeService.IsDivisible(number) && _divisionByFiveService.IsDivisible(number))
                {
                    result.Result = "FizzBuzz";
                }
                else if (_divisionByThreeService.IsDivisible(number))
                {
                    result.Result = "Fizz";
                }
                else if (_divisionByFiveService.IsDivisible(number))
                {
                    result.Result = "Buzz";
                }
                else
                {
                    result.Divisions.Add(_divisionByThreeService.DivisionMessage(number));
                    result.Divisions.Add(_divisionByFiveService.DivisionMessage(number));
                }
            }
            else
            {
                result.Result = "Invalid item";
            }

            return result;
        }
    }
}
