using FileConverterHomework.ConsoleClient.Storage;
using System;
using System.IO;
using Xunit;

namespace FileConverterHomework.Tests.Storage
{
    public class DiskStorageTests
    {
        [Theory]
        [InlineData("filename")]
        public void ReadNonExistent(string name)
        {
            var storage = new DiskStorage(Environment.CurrentDirectory);

            Assert.Throws<FileNotFoundException>(() => storage.ReadFile(name));
        }

        [Theory]
        [InlineData(new byte[] { 10, 20, 30 })]
        public void Write(byte[] file)
        {
            var storage = new DiskStorage(Environment.CurrentDirectory);

            var success = storage.WriteFile("test.txt", file);

            Assert.True(success);
        }
    }
}
