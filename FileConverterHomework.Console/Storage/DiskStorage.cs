using FileConverterHomework.ConsoleClient.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverterHomework.ConsoleClient.Storage
{
    public class DiskStorage : IStorage
    {
        public string RootPath { get; private set; }

        public DiskStorage(string rootPath)
        {
            RootPath = rootPath;
        }

        public Document ReadFile(string name)
        {
            try
            {
                var path = Path.Combine(RootPath, name);

                using (var fs = System.IO.File.OpenRead(path))
                using (var sr = new StreamReader(fs))
                {
                    var input = sr.ReadToEnd();
                }

                return new Document
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public bool WriteFile(string name, Document doc)
        {
            try
            {
                var path = Path.Combine(RootPath, name);

                using (var fs = System.IO.File.OpenWrite(path))
                using (var sw = new StreamWriter(fs))
                {
                    sw.Write(doc);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
