namespace FileConverterHomework.ConsoleClient.Storage
{
    public interface IStorage
    {
        public byte[] ReadFile(string name);
        public bool WriteFile(string name, byte[] file);
    }
}
