using FileConverterHomework.ConsoleClient.Types;
using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FileConverterHomework.ConsoleClient.Converters
{
    public class XmlConverter : IFileTypeConverter
    {
        public byte[] Convert(Document doc)
        {
            try
            {
                using var ms = new MemoryStream();
                
                var serializer = new XmlSerializer(typeof(Document));
                serializer.Serialize(ms, doc);

                return ms.ToArray();
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
                using (var ms = new MemoryStream(file))
                using (var sr = new StreamReader(ms))
                {
                    var input = sr.ReadToEnd();

                    var xdoc = XDocument.Parse(input);

                    var doc = new Document
                    {
                        Title = xdoc.Root.Element("title").Value,
                        Text = xdoc.Root.Element("text").Value
                    };

                    return doc;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
