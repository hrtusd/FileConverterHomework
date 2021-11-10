using FileConverterHomework.ConsoleClient.Converters;
using FileConverterHomework.ConsoleClient.Types;
using System;
using Xunit;

namespace FileConverterHomework.Tests.Converters
{
    public class JsonConverterTests : IDisposable
    {
        public Document Doc { get; set; }
        public Document ConvertedDoc { get; set; }

        public JsonConverterTests()
        {
            Doc = new Document()
            {
                Title = "Test",
                Text = "doc"
            };

            ConvertedDoc = new Document()
            {
                Data = new byte[] { 123, 34, 84, 105, 116, 108, 101, 34, 58, 34, 84, 101, 115, 116, 34, 44, 34, 84, 101, 120, 116, 34, 58, 34, 100, 111, 99, 34, 125 }
            };
        }

        [Theory]
        [InlineData(null)]
        public void ConvertNull(Document doc)
        {
            var converter = new JsonConverter();

            var result = converter.Convert(doc);

            Assert.Null(result);
        }

        [Fact]
        public void ConvertDoc()
        {
            var converter = new JsonConverter();

            var result = converter.Convert(Doc);

            Assert.Equal(ConvertedDoc.Data, result);
        }

        [Fact]
        public void ParseDoc()
        {
            var converter = new JsonConverter();

            var result = converter.Parse(ConvertedDoc.Data);

            Assert.Equal(Doc, result);
        }

        public void Dispose()
        {
            
        }
    }
}
