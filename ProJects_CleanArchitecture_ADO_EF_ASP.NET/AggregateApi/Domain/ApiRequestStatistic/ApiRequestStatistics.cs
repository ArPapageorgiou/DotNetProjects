namespace Domain.ApiRequestStatistic
{
    public class ApiRequestStatistics
    {
        public string ApiName { get; set; }
        public int TotalRequests { get; set; }
        public int FastRequests { get; set; }
        public int AverageRequests { get; set; }
        public int SlowRequests { get; set; }
        public double FastAverageTime { get; set; }
        public double AverageAverageTime { get; set; }
        public double SlowAverageTime { get; set; }
    }
}
