namespace FileGenerator.Managers {
    using Extensions;

    using System;
    using System.Timers;
    using System.IO;

    public class FileGenerator {
        private Timer FileTimer = null;

        public string TargetPath { get; set; }

        public uint GenerationPeriodSeconds { get; set; }

        public ulong MinimumFileSize { get; set; }

        public ulong MaximumFileSize { get; set; }

        public char FilePadding { get; set; } = '_';

        public void Start() {
            if (!SanityCheck()) {
                throw new ApplicationException("File Generator: One or more parameters invalid. Cannot start.");
            }

            // Initialize Timer
            if (this.FileTimer != null && this.FileTimer.Enabled) {
                throw new ApplicationException("File Generator: Cannot call Start() multiple times without first calling Stop().");
            }
            this.FileTimer = new Timer();
            this.FileTimer.Interval = Convert.ToDouble(this.GenerationPeriodSeconds * 1000);
            this.FileTimer.Elapsed += OnFileTimerElapsed;
            this.FileTimer.Start();
        }

        public void Stop() {
            if (this.FileTimer == null) {
                throw new ApplicationException("File Generator: Must call Start() before calling Stop().");
            }

            this.FileTimer.Stop();
        }

        private void OnFileTimerElapsed(object source, ElapsedEventArgs e) {
            var difference = Convert.ToInt32(this.MaximumFileSize - this.MinimumFileSize);
            var random = new Random();
            var fileSizeOffset = random.Next(0, difference);
            var fileSize = this.MinimumFileSize + Convert.ToUInt64(fileSizeOffset);

            var filename = this.GetFilename();
            var path = Path.Combine(this.TargetPath, filename);

            Console.WriteLine("Generating file: " + path);

            using (var stream = new FileStream(path, FileMode.Create)) {
                var chunk = this.GetFileChunk(16384);
                var bytes = System.Text.Encoding.UTF8.GetBytes(chunk);
                var written = 0;
                while (Convert.ToUInt64(written + bytes.Length) < fileSize) {
                    var dbgNewSize = Convert.ToUInt64(written + bytes.Length);
                    Console.WriteLine(dbgNewSize.ToString() + " written out of " + fileSize.ToString());
                    Console.WriteLine("Writing " + bytes.Length + " ...");
                    stream.Write(bytes, 0, bytes.Length);
                    written += bytes.Length;
                }
                chunk = this.GetFileChunk(Convert.ToInt32(fileSize - Convert.ToUInt64(written)));
                bytes = System.Text.Encoding.UTF8.GetBytes(chunk);
                stream.Write(bytes, 0, bytes.Length);

                stream.Close();
            }

            Console.WriteLine("Wrote file (" + fileSize.ToString() + " bytes)...");
        }

        private string GetFileChunk(int size) {
            // Can we do this faster?
            var paddingChar = Convert.ToChar(this.FilePadding);
            var result = paddingChar.ToString();
            while (result.Length < size) {
                result = result + this.FilePadding.ToString();
            }

            return result;
        }

        private string GetFilename() {
            var result = DateTime.UtcNow.Year.ToString() + DateTime.UtcNow.Month.ToString().PadLeftZeros(2) + DateTime.UtcNow.Day.ToString().PadLeftZeros(2) + "_";
            result += DateTime.UtcNow.Hour.ToString().PadLeftZeros(2) + DateTime.UtcNow.Minute.ToString().PadLeftZeros(2) + DateTime.UtcNow.Second.ToString().PadLeftZeros(2);
            result += DateTime.UtcNow.Millisecond.ToString() + ".junk";

            return result;
        }

        public bool SanityCheck() {
            return (this.MinimumFileSize <= this.MaximumFileSize) && (!string.IsNullOrWhiteSpace(this.TargetPath)) && (this.MaximumFileSize - this.MinimumFileSize <= int.MaxValue);
        }
    }
}