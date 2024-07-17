namespace Application.AppConstants
{
    public class CityName
    {
        public const string Athens = "athens";
        public const string Thessaloniki = "thessaloniki";
        //public const string Patra = "patras";
        //public const string Iraklion = "iraklion";
        //public const string Larissa = "larissa";

        public static List<string> GetCityNames()
        {
            return new List<string> { Athens, Thessaloniki };
        }
    }
}
