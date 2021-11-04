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
            IFileTypeConverter inputConverter = new JsonConverter();
            IFileTypeConverter outputConverter = new XmlConverter();

            IStorage inputStorage = new DiskStorage(Environment.CurrentDirectory);
            IStorage outputStorage = new DiskStorage(Environment.CurrentDirectory);

            //var file = inputStorage.ReadFile("in\\doc.xml");

            //var document = inputConverter.Parse(file);

            //var output = outputConverter.Convert(document);

            //outputStorage.WriteFile("out\\doc.json", output);

            //

            Document.LoadFrom(inputStorage, "in\\doc.json")
                .ParseWith(inputConverter)
                .ConvertWith(outputConverter)
                .SaveTo(outputStorage, "out\\doc.xml");
        }
    }
}
