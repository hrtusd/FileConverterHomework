using System;
using System.IO;
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

        public byte[] ReadFile(string name)
        {
            try
            {
                var path = Path.Combine(RootPath, name);

                using var fs = File.OpenRead(path);
                using var ms = new MemoryStream();
                
                fs.CopyTo(ms);

                return ms.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public bool WriteFile(string name, byte[] file)
        {
            try
            {
                var path = Path.Combine(RootPath, name);

                using var fs = File.OpenWrite(path);
                using var ms = new MemoryStream(file);

                ms.CopyTo(fs);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<byte[]> ReadFileAsync(string name)
        {
            try
            {
                var path = Path.Combine(RootPath, name);

                using var fs = File.OpenRead(path);
                using var ms = new MemoryStream();

                await fs.CopyToAsync(ms);

                return ms.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<bool> WriteFileAsync(string name, byte[] file)
        {
            try
            {
                var path = Path.Combine(RootPath, name);

                using var fs = File.OpenWrite(path);
                using var ms = new MemoryStream(file);

                await ms.CopyToAsync(fs);

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
