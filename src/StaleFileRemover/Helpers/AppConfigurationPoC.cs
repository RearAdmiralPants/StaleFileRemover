namespace StaleFileRemover.Helpers {
    using Abstractions;
    public static class AppConfigurationPoC {
        public static AppConfiguration GetPoc() {
            var poc = new AppConfiguration();

            poc.MonitorPath = "C:\\src\\";

            return poc;
        }
    }
}