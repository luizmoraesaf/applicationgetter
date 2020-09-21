using ApplicationGetter.WebApplication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationGetter.WebApi.Tests
{
    public class ApplicationControllerTests
    {
        private readonly TestServer server;
        private readonly HttpClient client;

        public ApplicationControllerTests()
        {
            var webHostBuilder = new WebHostBuilder()
                .UseStartup<Startup>();

            server = new TestServer(webHostBuilder);
            client = server.CreateClient();
        }

        [Test]
        public async Task TestAllApiEndpoints()
        {
            await GetAllApplications();
            await InsertOneApplication(1, "www.sss.com.br", "/3/3/txt", false);
        }

        private async Task GetAllApplications()
        {
            string result = await client.GetStringAsync("/api/GetList");
        }

        private async Task InsertOneApplication(int id, string url, string pathLocal, bool debbugingMode)
        {
            var json = new
            {
                id,
                url,
                pathLocal,
                debbugingMode
            };


            string data = JsonConvert.SerializeObject(json);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/Application/Add", content);

            response.EnsureSuccessStatusCode();
        }
    }
}