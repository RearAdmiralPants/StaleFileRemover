namespace Tests
{
    using NUnit.Framework;
    using NFluent;

    using System.IO;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPathCombination()
        {
            // Arrange
            var path = "C:\\src";
            var file = "testFile.txt";
            var expected = path + "\\" + file;

            // Act
            var combined = Path.Combine(path, file);

            // Assert
            ////WARN: Using NUnit + NFluent. May be too complex for such a small / straightforward project.
            Check.That(expected).IsEqualTo(combined);
        }
    }
}