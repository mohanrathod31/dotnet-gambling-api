namespace GambleAPI.GambleAPI.Application.Services
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private static readonly Random _random = new Random();

        public int Next(int maxValue)
        {
            return _random.Next(maxValue);
        }
    }
}
