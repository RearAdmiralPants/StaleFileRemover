namespace StaleFileRemover.Providers {
    using Abstractions;

    using Newtonsoft.Json;

    using System.IO;

    public class ConfigurationProvider {
        private const string APP_CONFIG_FILENAME = "StaleFileRemoverConfig.json";

        public string FilePath { get; set; }

        public AppConfiguration GetAppConfiguration() {
            if (string.IsNullOrWhiteSpace(this.FilePath)) {
                this.FindConfigFile();
            }

            var json = File.ReadAllText(this.FilePath);
            return (AppConfiguration)JsonConvert.DeserializeObject(json, typeof(AppConfiguration));
        }

        public void SaveAppConfiguration(AppConfiguration config) {
            var json = JsonConvert.SerializeObject(config);

            File.WriteAllText(this.FilePath, json);
        }

        public void FindConfigFile() {
            var execAssembly = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            var assemblyPath = Path.GetDirectoryName(execAssembly);
            
        }
    }
}