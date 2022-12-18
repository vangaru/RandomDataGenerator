using ShellProgressBar;

namespace RandomDataGenerator.Domain.Loggers
{
    public interface IProgressBar
    {
        public void RunWithProgressBar(Action<ProgressBar> action, int totalTicks);
    }
}
