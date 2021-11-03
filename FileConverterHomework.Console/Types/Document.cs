using FileConverterHomework.ConsoleClient.Converters;
using FileConverterHomework.ConsoleClient.Storage;
using System.Runtime.Serialization;

namespace FileConverterHomework.ConsoleClient.Types
{
    public class Document
    {
        public string Title { get; set; }
        public string Text { get; set; }


        [IgnoreDataMember]
        public byte[] Data { get; set; }

        public static Document Load(IStorage storage, string name)
        {
            var doc = new Document
            {
                Data = storage.ReadFile(name)
            };

            return doc;
        }
    }

    public static class DocumentExtensions
    {
        public static Document ConvertWith(this Document doc, IFileTypeConverter converter)
        {
            doc.Data = converter.Convert(doc);

            return doc;
        }

        public static Document ParseWith(this Document doc, IFileTypeConverter converter)
        {
            return converter.Parse(doc.Data);
        }

        public static bool SaveTo(this Document doc, IStorage storage, string name)
        {
            return storage.WriteFile(name, doc.Data);
        }
    }
}
