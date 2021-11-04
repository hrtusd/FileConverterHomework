using System.Threading.Tasks;

namespace FileConverterHomework.ConsoleClient.Storage
{
    public interface IStorage
    {
        public byte[] ReadFile(string name);
        public bool WriteFile(string name, byte[] file);

        public Task<byte[]> ReadFileAsync(string name);
        public Task<bool> WriteFileAsync(string name, byte[] file);
    }
}
