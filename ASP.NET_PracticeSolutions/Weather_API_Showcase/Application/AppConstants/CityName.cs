namespace Application.AppConstants
{
    public class CityName
    {
        public const string Athens = "Athens";
        public const string Thessaloniki = "Thessaloniki";
        public const string Patras = "Patras";
        public const string Heraklion = "Iraklion";
        public const string Larissa = "Larissa";
        public const string Volos = "Volos";
        public const string Ioannina = "Yiannena";
        public const string Chania = "Chania";
        public const string Agrinio = "Agrinio";
        public const string Kavala = "Kavala";

        public static List<String> GetCityNames() 
        { 
            return new List<string> { Athens, Thessaloniki, Patras, Heraklion, Larissa, Volos, Ioannina, Chania, Agrinio, Kavala };    
        }
    }
}
