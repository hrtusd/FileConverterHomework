using FileConverterHomework.ConsoleClient.Types;
using Newtonsoft.Json;
using System;
using System.IO;

namespace FileConverterHomework.ConsoleClient.Converters
{
    public class JsonConverter : IFileTypeConverter
    {
        public byte[] Convert(Document doc)
        {
            try
            {
                using var ms = new MemoryStream();
                using var sw = new StreamWriter(ms);

                var json = JsonConvert.SerializeObject(doc);

                sw.Write(json);
                sw.Flush();

                var data = ms.ToArray();

                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public Document Parse(byte[] file)
        {
            try
            {
                using var ms = new MemoryStream(file);
                using var sr = new StreamReader(ms);

                var doc = JsonConvert.DeserializeObject(sr.ReadToEnd(), typeof(Document)) as Document;

                return doc;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
