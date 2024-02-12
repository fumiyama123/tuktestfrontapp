using System.Runtime.Serialization.Json;
using System.Text.Json;


namespace tuktestfrontapp.Components.Pages
{
    public partial class Zodiac
    {
        public OrientalZodiacModel orientalZodiac = new();
        public string? year;

        public async Task ShowYear()
        {
            var parameters = new Dictionary<string, string>()
                {
                    { "code", "yg3fmpfzMBJA2eIBmAvlIJHZaxo7v0b8K6-yRREsM9i-AzFuHi4qlg==" },
                    { "year", year! }
                };  

            using (var client = new HttpClient())
            {
                var response =
                    await client.GetAsync($"https://tuktestfunc.azurewebsites.net/api/FunctionOrientalZodiac?{await new FormUrlEncodedContent(parameters).ReadAsStringAsync()}");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    orientalZodiac = JsonSerializer.Deserialize<OrientalZodiacModel>(jsonResponse)!;
                }
                else
                {
                    orientalZodiac.Value = "API通信に失敗しました。";
                }
            }
        }
    }
}
