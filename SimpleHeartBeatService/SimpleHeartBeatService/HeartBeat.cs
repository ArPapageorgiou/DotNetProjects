namespace SimpleHeartBeatService
{
    public class HeartBeat
    {
        private readonly System.Timers.Timer _timer;

        public HeartBeat()
        {
            _timer = new System.Timers.Timer(1000) { AutoReset = true };
            _timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            string[] lines = new string[] {DateTime.Now.ToString()};
            File.AppendAllLines(@"C:\Temporary\Demos\Heartbeat.txt", lines);
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
