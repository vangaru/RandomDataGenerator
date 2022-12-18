using ShellProgressBar;
using IProgressBar = RandomDataGenerator.Domain.Loggers.IProgressBar;

namespace RandomDataGenerator.ConsoleClient.Loggers
{
    public class ConsoleProgressBar : IProgressBar
    {
        public void RunWithProgressBar(Action<ProgressBar> action, int totalTicks)
        {
            var options = new ProgressBarOptions
            {
                ProgressCharacter = '#'
            };

            using var progressBar = new ProgressBar(totalTicks, string.Empty, options);
            action(progressBar);
        }
    }
}