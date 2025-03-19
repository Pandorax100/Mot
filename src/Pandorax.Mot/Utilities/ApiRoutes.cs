namespace Pandorax.Mot.Utilities;

internal static class ApiRoutes
{
    public static class MotHistory
    {
        public static string MotHistoryByRegistration(string vehicleRegistration)
        {
            return $"v1/trade/vehicles/registration/{vehicleRegistration}";
        }
    }
}
