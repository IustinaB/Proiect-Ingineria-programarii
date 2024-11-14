/**************************************************************************
 *                                                                        *
 *  File:        Weather.cs                                               *
 *  Copyright:   (c) 2023, Ivanov Alexandru                               *
 *  E-mail:      alexandru.ivanov@student.tuiasi.ro                       *
 *  Description: Clasa care returneaza vremea pentru o locatie in functie *
 *               de latitudine si longitudine                             *
 *                                                                        *
 **************************************************************************/

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace API
{   /// <summary>
    /// Clasă pentru a obține informații despre vremea pentru un nume de oraș și o dată specificată.
    /// </summary>
    public class Weather
    {
        private HttpClient _httpClient;
        /// <summary>
        /// Constructor public pentru a inițializa CLIENTUL HTTP.
        /// </summary>
        public Weather()
        {
            _httpClient = new HttpClient();

        }
        /// <summary>
        /// Funcție pentru a obține datele de la API-ul de vreme.
        /// </summary>
        /// <param name="lat">Latitudinea orașului furnizată de API-ul de geolocație.</param>
        /// <param name="lon">Longitudinea orașului furnizată de API-ul de geolocație.</param>
        /// <param name="date">Data la care trebuie să extragem informațiile despre vreme.</param>
        /// <returns>Corpul răspunsului API-ului de geolocație, așa cum este prezentat în clasa WeatherData.</returns>
        public async Task<string> GetStringByCoord(double lat,double lon,string date)
        {
            string responseBody = " ";
            try
            {
                HttpResponseMessage response = _httpClient.GetAsync("https://api.open-meteo.com/v1/forecast?" 
                    + "latitude=" + lat 
                    + "&longitude=" + lon 
                    + "&daily=weathercode,temperature_2m_max,temperature_2m_min" 
                    + "&start_date=" + date  
                    + "&end_date=" + date
                    + "&timezone=auto").Result;

                if (response.IsSuccessStatusCode)
                {
                    responseBody = response.Content.ReadAsStringAsync().Result;

                }
                else
                {
                    Console.WriteLine($"WeatherAPI call failed with status code {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            _httpClient.Dispose();
            return responseBody;
        }
        /// <summary>
        /// Funcție pentru a converti răspunsul în format JSON.
        /// </summary>
        /// <param name="lat">Latitudinea orașului furnizată de API-ul de geolocație.</param>
        /// <param name="lon">Longitudinea orașului furnizată de API-ul de geolocație.</param>
        /// <param name="date">Data la care trebuie să extragem informațiile despre vreme.</param>
        /// <returns>Un JSON WeatherData din care vom prelua valorile de care avem nevoie.</returns>
        public WeatherData GetWeatherData(double lat, double lon,string date)
        {

            Task<string> stringResponse = GetStringByCoord(lat, lon, date);

            return JsonConvert.DeserializeObject<WeatherData>(stringResponse.Result);
        }
    }
}
