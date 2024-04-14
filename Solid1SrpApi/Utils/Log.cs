namespace Solid1SrpApi.Utils
{
    public class Log
    {
        private readonly string _name = "log.txt";
        public async void Save(string content)
        {
            await File.WriteAllTextAsync(_name, content);

        }
    }
}
