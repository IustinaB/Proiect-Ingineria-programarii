/**************************************************************************
 *                                                                        *
 *  File:        GeocodingLoc.cs                                          *
 *  Copyright:   (c) 2023, Ivanov Alexandru                               *
 *  E-mail:      alexandru.ivanov@student.tuiasi.ro                       *
 *  Description: Clasa care returneaza latitudinea si longitudinea pentru *
 *               o locatie dupa un string dat                             *
 *                                                                        *
 **************************************************************************/

using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace API
{   /// <summary>
    /// Clasă pentru a obține geolocația pentru un nume de oraș dat.
    /// </summary>
    public class GeocodingLoc
    {
        private HttpClient _httpClient;
        /// <summary>
        /// Constructor public pentru a inițializa CLIENTUL HTTP și cheia necesară pentru API.
        /// </summary>
        public GeocodingLoc()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", "er4kKN1GFWVTZbhbqUH9wA==rxDpclohhWIcL1ua");
        }
        /// <summary>
        /// Funcție pentru a obține corpul răspunsului API-ului în mod asincron.
        /// </summary>
        /// <param name="location">Numele orașului/locului pentru a obține coordonatele.</param>
        /// <returns>Corpul răspunsului API-ului de geolocație, așa cum este prezentat în clasa Coordinates.</returns>
        public async Task<string> GetStringGeo(string location)
        {
            string responseBody = " ";
            try
            {
                 HttpResponseMessage response =  _httpClient.GetAsync("https://api.api-ninjas.com/v1/geocoding?city=" + location).Result;

                if (response.IsSuccessStatusCode)
                {
                    responseBody = response.Content.ReadAsStringAsync().Result;

                }
                else
                {
                    throw new System.Exception($"Geocoding API call failed with status code {response.StatusCode}");
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception($"An error occurred: {ex.ToString()}");
            }
            _httpClient.Dispose();
            // return responseBody;
            // Varianta alternativa pentru test successful
            return await Task.FromResult(responseBody);
        }
        /// <summary>
        /// Funcție pentru a converti răspunsul în format JSON.
        /// </summary>
        /// <param name="strLocation">Numele orașului/locului pentru a obține coordonatele.</param>
        /// <returns>Un JSON din care trebuie să preluăm coordonatele.</returns>
        public Coordinates[] GetLocationCoord(string strLocation)
        {
            Task<string> responseAsString = GetStringGeo(strLocation);

            return JsonConvert.DeserializeObject<Coordinates[]>(responseAsString.Result);

        }
    }
}
