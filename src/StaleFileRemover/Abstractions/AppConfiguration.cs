namespace StaleFileRemover.Abstractions {
    using System;

    public class AppConfiguration {
        public DateTime LastOpened { get; set; } = DateTime.MinValue;
        
        public string MonitorPath { get; set; }

        public long MaximumDirectorySize { get; set; }
    }
}