namespace StaleFileRemover.Abstractions {
    public class AppConfiguration {
        public string MonitorPath { get; set; }

        public long MaximumDirectorySize { get; set; }
    }
}