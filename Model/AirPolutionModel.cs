using System.Text.Json.Serialization;


namespace WeartherServeApi.Model
{
    public class AirPolutionModel
    {
        [JsonPropertyName("coord")]
        public Coord Coord { get; set; }

        [JsonPropertyName("list")]
        public List<ListItem> List { get; set; }
    }

    public class Coord1
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lon")]
        public double Lon { get; set; }
    }

    public class Main1
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; } 

        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }  

        [JsonPropertyName("tem_min")]
        public double TempMin { get; set; }  

        [JsonPropertyName("temp_max")]
        public double TempMax { get; set; }

        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("sea_level")]
        public int SeaLevel { get; set; }

        [JsonPropertyName("grnd_level")]
        public int GrndLevel { get; set; }
    }

    public class Components
    {
        [JsonPropertyName("co")]
        public double Co { get; set; }

        [JsonPropertyName("no")]
        public double No { get; set; }

        [JsonPropertyName("no2")]
        public double No2 { get; set; }

        [JsonPropertyName("o3")]
        public double O3 { get; set; }

        [JsonPropertyName("so2")]
        public double So2 { get; set; }

        [JsonPropertyName("pm2_5")]
        public double Pm2_5 { get; set; }

        [JsonPropertyName("pm10")]
        public double Pm10 { get; set; }

        [JsonPropertyName("nh3")]
        public double Nh3 { get; set; }
    }

    public class ListItem
    {
        [JsonPropertyName("dt")]
        public long Dt { get; set; }

        [JsonPropertyName("main")]
        public Main Main { get; set; }

        [JsonPropertyName("components")]
        public Components Components { get; set; }
    }
}
