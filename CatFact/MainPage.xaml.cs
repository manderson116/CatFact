using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CatFact
{
    public partial class MainPage : ContentPage
    {
        HttpClient client = new HttpClient();

        public class CatFact
        {
            public string fact { get; set; }
            public int length { get; set; }
        }

        private async Task GetFact()
        {
            HttpResponseMessage response = await client.GetAsync("https://catfact.ninja/fact");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                CatFact catFact = JsonConvert.DeserializeObject<CatFact>(json);
                FactLabel.Text = catFact.fact;
            }
        }

        public MainPage()
        {
            InitializeComponent();
            GetFact();
        }

        private void FactBtnClicked(object sender, EventArgs e)
        {
            GetFact();
        }
    }
}
