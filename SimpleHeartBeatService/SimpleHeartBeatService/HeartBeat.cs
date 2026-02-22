namespace SimpleHeartBeatService
{
    public class HeartBeat
    {
        private readonly System.Timers.Timer _timer;

        // ===== Define a service-safe, machine-wide log file path (ProgramData) =====
        private readonly string _filePath;

        public HeartBeat()
        {
            _timer = new System.Timers.Timer(1000) { AutoReset = true };
            _timer.Elapsed += Timer_Elapsed;

            // ===== Build the path under C:\ProgramData\SimpleHeartBeatService\Heartbeat.txt =====
            _filePath = Path.Combine(Environment.GetFolderPath
                (Environment.SpecialFolder.CommonApplicationData), "SimpleHeartBeatService", "HeartBeat.txt");

            // ===== Ensure the folder exists before timer starts writing =====
            Directory.CreateDirectory(Path.GetDirectoryName(_filePath)!);
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            // Use ISO 8601 timestamp for stable logs =====
            string[] lines = new string[] {DateTime.Now.ToString("O")};
            // ===== Write to ProgramData-based path instead of a hardcoded dev folder =====
            try
            {
                File.AppendAllLines(_filePath, new[] { DateTime.Now.ToString("O") });
            }
            catch
            {
                // In real service code, we would log to Event Log or an internal logger
            }
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
