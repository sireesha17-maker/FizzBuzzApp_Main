namespace FizzBuzzAPI.Models
{
    public class FizzBuzzResult
    {
        public string Input { get; set; }
        public string Result { get; set; }
        public List<string> Divisions { get; set; } = new List<string>();
    }
}
