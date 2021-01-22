using System.Collections.Generic;

namespace MovieNinjaWASM.Models 
{
    public class SeaonCreditSet 
    {
        public int id { get; set; }
        public List<SeaonCast> cast { get; set; }
        public List<SeaonCrew> crew { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class SeaonCast    
    {
        public bool adult { get; set; } 
        public int gender { get; set; } 
        public int id { get; set; } 
        public string known_for_department { get; set; } 
        public string name { get; set; } 
        public string original_name { get; set; } 
        public double popularity { get; set; } 
        public string profile_path { get; set; } 
        public string character { get; set; } 
        public string credit_id { get; set; } 
        public int order { get; set; } 
    }

    public class SeaonCrew    
    {
        public bool adult { get; set; } 
        public int gender { get; set; } 
        public int id { get; set; } 
        public string known_for_department { get; set; } 
        public string name { get; set; } 
        public string original_name { get; set; } 
        public double popularity { get; set; } 
        public string profile_path { get; set; } 
        public string credit_id { get; set; } 
        public string department { get; set; } 
        public string job { get; set; } 
    }


    public class TvCast    {
        public string backdrop_path { get; set; } 
        public List<int> genre_ids { get; set; } 
        public string original_language { get; set; } 
        public string name { get; set; } 
        public int vote_count { get; set; } 
        public double vote_average { get; set; } 
        public string poster_path { get; set; } 
        public string overview { get; set; } 
        public string first_air_date { get; set; } 
        public string original_name { get; set; } 
        public List<string> origin_country { get; set; } 
        public int id { get; set; } 
        public double popularity { get; set; } 
        public string character { get; set; } 
        public string credit_id { get; set; } 
        public int episode_count { get; set; } 
    }

    public class TvCrew    {
        public double vote_average { get; set; } 
        public int id { get; set; } 
        public string overview { get; set; } 
        public string backdrop_path { get; set; } 
        public string original_name { get; set; } 
        public List<string> origin_country { get; set; } 
        public int vote_count { get; set; } 
        public string original_language { get; set; } 
        public List<int> genre_ids { get; set; } 
        public string poster_path { get; set; } 
        public string name { get; set; } 
        public string first_air_date { get; set; } 
        public double popularity { get; set; } 
        public string credit_id { get; set; } 
        public string department { get; set; } 
        public int episode_count { get; set; } 
        public string job { get; set; } 
    }

    public class TvCreditSet    {
        public List<TvCast> cast { get; set; } 
        public List<TvCrew> crew { get; set; } 
        public int id { get; set; } 
    }










}

