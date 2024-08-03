namespace Domain.FootballAPI_ModelClasses
{
    public class Home
    {
        public int Played { get; set; }
        public int Win { get; set; }
        public int Draw { get; set; }
        public int Lose { get; set; }
        public Goals Goals { get; set; }
    }
}
