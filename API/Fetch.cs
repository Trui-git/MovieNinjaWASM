using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using MovieNinjaWASM.Models;

namespace MovieNinjaWASM.API {
    public class Fetch {
        public string cs = "Server=(localdb)\\ProjectsV13;Database=MovieNinjaDB;Trusted_Connection=true";
        public HttpClient client = new HttpClient();
        public const string API_KEY = "60918711ab06f46cb045b0ee80dcebd9";
        public string Data { get; set; }   
        public string Videos { get; set; }
        public string Season { get; set; }
        public string Episode { get; set; }
        public string Details { get; set; }
        public string Credits { get; set; }
        public string ActoreDetail { get; set; }

        public async Task GetTrends() { 
            ClearHeaders();

            // Get the latest trends in Movies
            HttpResponseMessage response = await client.GetAsync(
                "https://api.themoviedb.org/3/trending/tv/day?api_key=" + API_KEY);

            if(response.IsSuccessStatusCode) {
                Data = await response.Content.ReadAsStringAsync();
                Program.trendSet = JsonSerializer.Deserialize<TrendSet>(Data);
            }
            else {
                Data = null;
            }
        } // GetTrends()

        public async Task Search(string search) {
            ClearHeaders();

            // Does a movie search
            HttpResponseMessage response = await client.GetAsync(
                "https://api.themoviedb.org/3/search/tv?api_key=" + API_KEY + "&query=" + search);

            if(response.IsSuccessStatusCode) {
                Data = await response.Content.ReadAsStringAsync();
                Program.posterSet = JsonSerializer.Deserialize<PosterSet>(Data);
            }
            else {
                Data = null;
            }
        } // Search()

        public async Task GetDetails(string tvID) {
            ClearHeaders();

            //===========================>>
            // Grabs Video details
            HttpResponseMessage videoDetails =
                await client.GetAsync(
                    "https://api.themoviedb.org/3/tv/" + tvID
                                      + "/videos?api_key=" + API_KEY + "&language=en-US");

            HttpResponseMessage movieDetails =
            await client.GetAsync(
                "https://api.themoviedb.org/3/tv/" + tvID 
                    + "?api_key=" + API_KEY + "&language=en-US");

            HttpResponseMessage castDetails =
            await client.GetAsync(
                "https://api.themoviedb.org/3/tv/" + tvID +
                    "/credits?api_key=" + API_KEY);

            if (videoDetails.IsSuccessStatusCode || 
                movieDetails.IsSuccessStatusCode )
            {
                Videos = await videoDetails.Content.ReadAsStringAsync();
                Details = await movieDetails.Content.ReadAsStringAsync();
                Credits = await castDetails.Content.ReadAsStringAsync();
                Program.videoSet = JsonSerializer.Deserialize<VideoSet>(Videos);
                Program.tv = JsonSerializer.Deserialize<Tv>(Details);
            }
            else
            {
                Data = null;
            }
        } // GetDetails()

        public async Task GetSeasonDetails(string tvID, string seasonNum) {
            ClearHeaders();

            //===========================>>
            // Grabs Video details
            HttpResponseMessage seasonDetails =
                await client.GetAsync(
                    "https://api.themoviedb.org/3/tv/" + tvID + "/season/" + seasonNum + 
                    "?api_key=" + API_KEY + "&language=en-US");

            HttpResponseMessage castDetails =
                await client.GetAsync(
                    "https://api.themoviedb.org/3/tv/" + tvID + "/season/" + seasonNum +
                    "/credits?api_key=" + API_KEY);

            HttpResponseMessage tvDetails =
                await client.GetAsync(
                    "https://api.themoviedb.org/3/tv/" + tvID 
                        + "?api_key=" + API_KEY + "&language=en-US");        

            if (seasonDetails.IsSuccessStatusCode ||
                castDetails.IsSuccessStatusCode ||
                tvDetails.IsSuccessStatusCode)
            {
                Season = await seasonDetails.Content.ReadAsStringAsync();
                Credits = await castDetails.Content.ReadAsStringAsync();
                Details = await tvDetails.Content.ReadAsStringAsync();
                Program.seasonDetail = JsonSerializer.Deserialize<SeasonDetail>(Season);
                Program.seasonCreditSet = JsonSerializer.Deserialize<SeaonCreditSet>(Credits);
                Program.tv = JsonSerializer.Deserialize<Tv>(Details);
            }
            else
            {
                Data = null;
            }
        } // GetSeaonDetails()


        public async Task GetEpisodeDetails(string tvID, string seasonNum, string episodeNum) {
            ClearHeaders();

            //===========================>>
            // Grabs Video details
            HttpResponseMessage episodeDetails =
                await client.GetAsync(
                    "https://api.themoviedb.org/3/tv/" + tvID + "/season/" + seasonNum + "/episode/" + episodeNum +
                    "?api_key=" + API_KEY + "&language=en-US");
       
            if (episodeDetails.IsSuccessStatusCode)
            {
                Episode = await episodeDetails.Content.ReadAsStringAsync();
                Program.episodeDetail = JsonSerializer.Deserialize<Episode>(Episode);
            }
            else
            {
                Data = null;
            }
        } // GetEpisodeDetails()

        public async Task GetActorDetails(string actorID) {
            ClearHeaders();

            //===========================>>
            // Grabs Video details
            HttpResponseMessage actorDetails =
                await client.GetAsync(
                    "https://api.themoviedb.org/3/person/" + actorID + "?api_key=" + API_KEY);

            HttpResponseMessage tvCreditSet =
                await client.GetAsync("https://api.themoviedb.org/3/person/" + actorID 
                    + "/tv_credits" + "?api_key=" + API_KEY + "&language=en-US");
   
            if (actorDetails.IsSuccessStatusCode|| 
                tvCreditSet.IsSuccessStatusCode)
            {
                ActoreDetail = await actorDetails.Content.ReadAsStringAsync();
                Program.actor = JsonSerializer.Deserialize<Actor>(ActoreDetail);
                Data = await tvCreditSet.Content.ReadAsStringAsync();
                Program.tvCreditSet = JsonSerializer.Deserialize<TvCreditSet>(Data);
            }
            else
            {
                Data = null;
            }
        } // GetActorDetails()

        public void ClearHeaders() {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applicationException/json"));
        }
    }
}