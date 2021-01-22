using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MovieNinjaWASM.Models;
using MovieNinjaWASM.API;

namespace MovieNinjaWASM
{
    public class Program
    {
        public static Fetch fetch = new Fetch(); // API method call to TMDB
        public static TrendSet trendSet = new TrendSet();
        public static PosterSet posterSet = new PosterSet();
        public static Movie movie = new Movie();
        public static Tv tv = new Tv();
        public static Actor actor = new Actor();
        public static TvCreditSet tvCreditSet = new TvCreditSet();
        public static SeasonDetail seasonDetail = new SeasonDetail();
        public static Episode episodeDetail = new Episode();
        public static VideoSet videoSet = new VideoSet();
        public static SeaonCreditSet seasonCreditSet = new SeaonCreditSet();
        public static int userID = 0;
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
