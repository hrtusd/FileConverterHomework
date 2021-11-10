using FileConverterHomework.ConsoleClient.Converters;
using FileConverterHomework.ConsoleClient.Storage;
using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FileConverterHomework.ConsoleClient.Types
{
    public class Document
    {
        public string Title { get; set; }
        public string Text { get; set; }


        [IgnoreDataMember]
        public byte[] Data { get; set; }

        public static Document LoadFrom(IStorage storage, string name)
        {
            try
            {
                var doc = new Document
                {
                    Data = storage.ReadFile(name)
                };

                return doc;
            }
            catch (Exception)
            {
                //Console.WriteLine(e.Message);
                throw;
            }
        }

        public static async Task<Document> LoadFromAsync(IStorage storage, string name)
        {
            try
            {
                var doc = new Document
                {
                    Data = await storage.ReadFileAsync(name)
                };

                return doc;
            }
            catch (Exception)
            {
                //Console.WriteLine(e.Message);
                throw;
            }
        }
    }

    public static class DocumentExtensions
    {
        public static Document ConvertWith(this Document doc, IFileTypeConverter converter)
        {
            try
            {
                doc.Data = converter.Convert(doc);

                return doc;
            }
            catch (Exception)
            {
                //Console.WriteLine(e.Message);
                throw;
            }
        }

        public static Document ParseWith(this Document doc, IFileTypeConverter converter)
        {
            try
            {
                return converter.Parse(doc.Data);
            }
            catch (Exception)
            {
                //Console.WriteLine(e.Message);
                throw;
            }
        }

        public static bool SaveTo(this Document doc, IStorage storage, string name)
        {
            try
            {
                return storage.WriteFile(name, doc.Data);
            }
            catch (Exception)
            {
                //Console.WriteLine(e.Message);
                throw;
            }
        }

        public static async Task<bool> SaveToAsync(this Document doc, IStorage storage, string name)
        {
            try
            {
                return await storage.WriteFileAsync(name, doc.Data);
            }
            catch (Exception)
            {
                //Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
