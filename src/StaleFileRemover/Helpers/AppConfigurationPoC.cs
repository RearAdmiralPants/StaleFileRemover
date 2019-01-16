namespace StaleFileRemover.Helpers {
    using Abstractions;

    using System;
    public static class AppConfigurationPoC {
        public static AppConfiguration GetPocConfig() {
            var poc = new AppConfiguration();

            poc.MonitorPath = "C:\\Test\\TestStaleDirectory";
            poc.MaximumDirectorySize = 100000000;
            poc.LastOpened = DateTime.Now.Subtract(new TimeSpan(24, 0, 0));

            return poc;
        }
    }
}