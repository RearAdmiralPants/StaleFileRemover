namespace FileGenerator.Extensions {
    public static class StringExtensions {
        public static string PadLeftChar(this string input, char padding, int totalLength) {
            while (input.Length < totalLength) {
                input = padding.ToString() + input;
            }

            return input;
        }

        public static string PadLeftZeros(this string input, int totalLength) {
            return PadLeftChar(input, '0', totalLength);
        }
    }
}