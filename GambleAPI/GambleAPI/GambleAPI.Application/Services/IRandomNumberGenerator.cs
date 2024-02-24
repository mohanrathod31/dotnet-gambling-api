namespace GambleAPI.GambleAPI.Application.Services
{
    public interface IRandomNumberGenerator
    {
        int Next(int maxValue);
    }
}
