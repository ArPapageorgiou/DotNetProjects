namespace Domain.FootballAPI_ModelClasses
{
    namespace ApiFootball
    {
        public class ApiResponse
        {
            public string Get { get; set; }
            public Parameters Parameters { get; set; }

            //public Dictionary<string, string> Errors { get; set; } = new Dictionary<string, string>();
            public string[] Errors { get; set; }

            public int Results { get; set; }
            public Paging Paging { get; set; }
            public List<Response> Response { get; set; }
        }
    }

}
