using FileConverterHomework.ConsoleClient.Types;

namespace FileConverterHomework.ConsoleClient.Converters
{
    public interface IFileTypeConverter
    {
        public Document Parse(byte[] file);
        public byte[] Convert(Document doc);
    }
}
