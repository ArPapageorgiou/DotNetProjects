using Topshelf;

namespace SimpleHeartBeatService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<HeartBeat>(s =>
                {
                    s.ConstructUsing(heartbeat => new HeartBeat());
                    s.WhenStarted(heartbeat => heartbeat.Start());
                    s.WhenStopped(heartbeat => heartbeat.Stop());
                });

                x.RunAsLocalSystem();

                x.SetDescription("A simple heartbeat service that logs a message every second.");
                x.SetDisplayName("Simple Heartbeat Service");
                x.SetServiceName("SimpleHeartBeatService"); 
                x.StartAutomatically();
            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
