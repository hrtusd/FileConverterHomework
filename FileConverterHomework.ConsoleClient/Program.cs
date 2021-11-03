using FileConverterHomework.ConsoleClient.Converters;
using FileConverterHomework.ConsoleClient.Storage;
using FileConverterHomework.ConsoleClient.Types;
using System;

namespace FileConverterHomework.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IFileTypeConverter inputConverter = new XmlConverter();
            IFileTypeConverter outputConverter = new JsonConverter();

            IStorage inputStorage = new DiskStorage(Environment.CurrentDirectory);
            IStorage outputStorage = new DiskStorage(Environment.CurrentDirectory);

            var file = inputStorage.ReadFile("Document.xml");

            var document = inputConverter.Parse(file);

            var output = outputConverter.Convert(document);

            outputStorage.WriteFile("Document.json", output);


            //

            Document.Load(inputStorage, "Document.xml")
                .ParseWith(inputConverter)
                .ConvertWith(outputConverter)
                .SaveTo(outputStorage, "Document.json");
        }
    }
}
