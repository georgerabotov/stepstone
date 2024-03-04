namespace Stepstone.Api.Extensions
{
    public static class ValidationExtension
    {
        public static bool BeAGuid(string value)
        {
            return Guid.TryParse(value, out _);
        }
    }
}
