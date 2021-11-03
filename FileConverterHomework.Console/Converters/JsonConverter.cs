using FileConverterHomework.ConsoleClient.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverterHomework.ConsoleClient.Converters
{
    public class JsonConverter : IFileTypeConverter
    {
        public byte[] Convert(Document doc)
        {
            throw new NotImplementedException();
        }

        public Document Parse(byte[] file)
        {
            throw new NotImplementedException();
        }
    }
}
