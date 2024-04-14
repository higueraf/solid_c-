using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Solid5Dip
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Dependency inversion principle (DIP)
            // High-level modules should not depend on low-level modules,
            // but both should depend on abstractions.
            string jsonContent = @"[{""userId"": 1,""id"": 1,""title"": ""delectus aut autem"",""completed"": false},{""userId"": 1,""id"": 2,""title"": ""quis ut nam facilis et officia qui"",""completed"": false},{""userId"": 1,""id"": 3,""title"": ""fugiat veniam minus"",""completed"": false},{""userId"": 1,""id"": 4,""title"": ""et porro tempora"",""completed"": true}]";
            string fakeFilePath = "fakePosts.json";
            File.WriteAllText(fakeFilePath, jsonContent);
            FileDB fileDb = new FileDB(fakeFilePath, new InfoByFile(fakeFilePath));
            await fileDb.Save();
            string fakeUrl = "https://jsonplaceholder.typicode.com/todos";
            Monitor requestMonitor = new Monitor(fakeUrl, new InfoByRequest(fakeUrl));
            await requestMonitor.Show();
        }
    }

    public class Monitor
    {
        private string _origin;
        private IInfo _info;
        public Monitor(string origin, IInfo info)
        {
            _origin = origin;
            _info = info;
        }
        public async Task Show()
        {
            var posts = await _info.Get();
            foreach (var post in posts)
            {
                Console.WriteLine(post.title);
            }
        }
    }

    public class FileDB
    {
        private string _path;
        private IInfo _info;
        public FileDB(string path, IInfo info)
        {
            _path = path;
            _info = info;
        }
        public async Task Save()
        {
            var posts = await _info.Get();
            string json = JsonSerializer.Serialize(posts);
            await File.WriteAllLinesAsync(_path, new string[] { json });
        }
    }

    public class InfoByFile : IInfo
    {
        private string _path;
        public InfoByFile(string path)
        {
            _path = path;
        }
        public async Task<IEnumerable<Post>> Get()
        {
            using (var contentStream = new FileStream(_path, FileMode.Open, FileAccess.Read))
            {
                IEnumerable<Post> posts = await JsonSerializer.DeserializeAsync<IEnumerable<Post>>(contentStream);
                return posts;
            }
        }
    }

    public class InfoByRequest : IInfo
    {
        private string _url;
        public InfoByRequest(string url)
        {
            _url = url;
        }
        public async Task<IEnumerable<Post>> Get()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(_url);
            var stream = await response.Content.ReadAsStreamAsync();
            List<Post> posts = await JsonSerializer.DeserializeAsync<List<Post>>(stream);
            return posts;
        }
    }

    public interface IInfo
    {
        Task<IEnumerable<Post>> Get();
    }

    public class Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }
        public int userId { get; set; }
    }
}
