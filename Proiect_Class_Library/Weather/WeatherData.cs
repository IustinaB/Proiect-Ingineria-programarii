/**************************************************************************
 *                                                                        *
 *  File:        WeatherData.cs                                           *
 *  Copyright:   (c) 2023, Ivanov Alexandru                               *
 *  E-mail:      alexandru.ivanov@student.tuiasi.ro                       *
 *  Description: Clasa care cuprinde datele returnate de catre API-ul de  *
 *               vreme intr-un obiect de tip json                         *
 *               + dictionarul WeatherCodes care converteste codul vremii * 
 *               intr-un string                                           *
 *                                                                        *
 **************************************************************************/


using System.Collections.Generic;
using Newtonsoft.Json;

namespace API
{   /// <summary>
    /// Clasă pentru a obține JSON-ul corespunzător datelor returnate de API-ul Weather Data
    /// </summary>
    public class WeatherData
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("generationtime_ms")]
        public double GenerationTimeMs { get; set; }

        [JsonProperty("utc_offset_seconds")]
        public int UtcOffsetSeconds { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("timezone_abbreviation")]
        public string TimezoneAbbreviation { get; set; }

        [JsonProperty("elevation")]
        public double Elevation { get; set; }

        [JsonProperty("daily_units")]
        public DailyUnits DailyUnits { get; set; }

        [JsonProperty("daily")]
        public DailyData Daily { get; set; }
    }
    /// <summary>
    /// Clasă utilitară utilizată de WeatherData pentru a obține corect JSON-ul
    /// </summary>
    public class DailyUnits
    {
        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("weathercode")]
        public string WeatherCode { get; set; }

        [JsonProperty("temperature_2m_max")]
        public string Temperature2mMax { get; set; }

        [JsonProperty("temperature_2m_min")]
        public string Temperature2mMin { get; set; }
    }
    /// <summary>
    /// Clasă utilitară folosită de WeatherData pentru a obține corect JSON-ul.
    /// </summary>
    public class DailyData
    {
        [JsonProperty("time")]
        public List<string> Time { get; set; }

        [JsonProperty("weathercode")]
        public List<int> WeatherCode { get; set; }

        [JsonProperty("temperature_2m_max")]
        public List<double> Temperature2mMax { get; set; }

        [JsonProperty("temperature_2m_min")]
        public List<double> Temperature2mMin { get; set; }
    }

    /// <summary>
    /// Clasă statică pentru a converti codurile meteo în șiruri de caractere.
    /// </summary>
    public static class WeatherCodes
    {   
        public static Dictionary<int, string> weatherDescriptions = new Dictionary<int, string>()
        {
            { 0, "Clear sky" },
            { 1, "Mainly clear" },
            { 2, "Partly cloudy" },
            { 3, "Overcast" },
            { 45, "Fog" },
            { 48, "Rime fog" },
            { 51, "Drizzle: Light" },
            { 53, "Drizzle: Moderate" },
            { 55, "Drizzle: Dense intensity" },
            { 56, "Freezing Drizzle: Light intensity" },
            { 57, "Freezing Drizzle: Dense intensity" },
            { 61, "Rain: Slight intensity" },
            { 63, "Rain: Moderate intensity" },
            { 65, "Rain: Heavy intensity" },
            { 66, "Freezing Rain: Light intensity" },
            { 67, "Freezing Rain: Heavy intensity" },
            { 71, "Snow fall: Slight intensity" },
            { 73, "Snow fall: Moderate intensity" },
            { 75, "Snow fall: Heavy intensity" },
            { 77, "Snow grains" },
            { 80, "Rain showers: Slight intensity" },
            { 81, "Rain showers: Moderate intensity" },
            { 82, "Rain showers: Violent intensity" },
            { 85, "Snow showers: Slight intensity" },
            { 86, "Snow showers: Heavy intensity" },
            { 95, "Thunderstorm: Slight or moderate" },
            { 96, "Thunderstorm with slight hail" },
            { 99, "Thunderstorm with heavy hail" }
        };
    }

}