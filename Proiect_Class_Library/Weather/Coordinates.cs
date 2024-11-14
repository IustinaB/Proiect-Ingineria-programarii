/**************************************************************************
 *                                                                        *
 *  File:        Coordinates.cs                                           *
 *  Copyright:   (c) 2023, Ivanov Alexandru                               *
 *  E-mail:      alexandru.ivanov@student.tuiasi.ro                       *
 *  Description: Clasa care cuprinde datele returnate de catre API-ul de  *
 *               geolocatie intr-un obiect de tip json.                   *
 *                                                                        *
 **************************************************************************/

using Newtonsoft.Json;


namespace API
{   /// <summary>
    /// Clasă pentru a obține JSON-ul corespunzător coordonatelor orașului introdus returnat de către API-ul de geolocație.
    /// </summary>
    public class Coordinates
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
