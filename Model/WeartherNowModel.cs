﻿using System.Text.Json.Serialization;

namespace WeartherServeApi.Model
{
    public class WeartherNowModel
    {
        [JsonPropertyName("coord")]
        public Coord? Coord { get; set; }

        [JsonPropertyName("weather")]
        public Weather[]? Weather { get; set; }

        [JsonPropertyName("base")]
        public string? Base { get; set; }

        [JsonPropertyName("main")]
        public Main? Main { get; set; }

        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }

        [JsonPropertyName("wind")]
        public Wind? Wind { get; set; }

        [JsonPropertyName("clouds")]
        public Clouds? Clouds { get; set; }

        [JsonPropertyName("dt")]
        public int Dt { get; set; }

        [JsonPropertyName("sys")]
        public Sys? Sys { get; set; }

        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("cod")]
        public int Cod { get; set; }
    }

    public class Coord
    {
        [JsonPropertyName("lon")]
        public float Lon { get; set; }

        [JsonPropertyName("lat")]
        public float Lat { get; set; }
    }

    public class Weather
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("main")]
        public string? Main { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("icon")]
        public string? Icon { get; set; }
    }

    public class Main
    {
        [JsonPropertyName("temp")]
        public float Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public float FeelsLike { get; set; }

        [JsonPropertyName("temp_min")]
        public float TempMin { get; set; }

        [JsonPropertyName("temp_max")]
        public float TempMax { get; set; }

        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("sea_level")]
        public int SeaLevel { get; set; }

        [JsonPropertyName("grnd_level")]
        public int GrndLevel { get; set; }
    }

    public class Wind
    {
        [JsonPropertyName("speed")]
        public float Speed { get; set; }

        [JsonPropertyName("deg")]
        public int Deg { get; set; }

        [JsonPropertyName("gust")]
        public float Gust { get; set; }
    }

    public class Clouds
    {
        [JsonPropertyName("all")]
        public int All { get; set; }
    }

    public class Sys
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("sunrise")]
        public int Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public int Sunset { get; set; }
    }
}
