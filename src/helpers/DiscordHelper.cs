namespace DiscordHelper
{
    using System.Net.Http;
    using System.Net.WebSockets;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Logger;

    public static class HttpService
    {
        private static string nowTime = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        private static readonly HttpClient client = new HttpClient();

        static HttpService()
        {
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (X11; Linux x86_64; rv:147.0) Gecko/20100101 Firefox/147.0");
        }

        public static async Task<string> GetAsyncJson(string url, string? token = null)
        {
            if (!string.IsNullOrEmpty(token))
            {
                if (client.DefaultRequestHeaders.Contains("Authorization"))
                {
                    client.DefaultRequestHeaders.Remove("Authorization");
                }

                client.DefaultRequestHeaders.Add("Authorization", $"{token}");
            }

            string response = await client.GetStringAsync(url);

            // var data = JsonSerializer.Deserialize<Dictionary<string, object>>(response);
            return response;
        }
    }

    public class DiscordUser
    {
        public string id { get; set; }
        public string username { get; set; }
        public string global_name { get; set; }
    }

    public static class DiscordAPI
    {

        private static readonly HttpClient client = new HttpClient();
        private static string baseURL = "https://discord.com/api/v10";
        private static string authToken = File.ReadAllText(AppContext.BaseDirectory + "usr.token"); //do not share

        public static async Task<DiscordUser> GetCurrentUser()
        {
            string fullURL = baseURL + "/users/@me";
            var json = await HttpService.GetAsyncJson(fullURL, authToken);

            var usr = JsonSerializer.Deserialize<DiscordUser>(json);
            return usr;
        }

        public static async Task Login()
        {

        }
    }
}