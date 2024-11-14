/**************************************************************************
 *                                                                        *
 *  File:        WeatherMain.cs                                           *
 *  Copyright:   (c) 2023, Ivanov Alexandru                               *
 *  E-mail:      alexandru.ivanov@student.tuiasi.ro                       *
 *  Description: Clasa care realizeaza comunicatia dintre cele 2 API-uri  *
 *                                                                        *
 **************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{   /// <summary>
    /// Clasă pentru a combina cele două API-uri într-unul singur.
    /// </summary>
    public class WeatherMain
    {   
        private Weather _weather;
        private GeocodingLoc _geocodingLoc;

        /// <summary>
        /// Constructor public pentru a inițializa ambele clase API.
        /// </summary>
        public WeatherMain()
        {
            this._weather = new Weather();
            this._geocodingLoc = new GeocodingLoc();

        }
        /// <summary>
        /// Funcție pentru a returna informațiile meteo finale de care avem nevoie pentru aplicație.
        /// </summary>
        /// <param name="city">Numele orașului dat.</param>
        /// <param name="date">Data pentru care avem nevoie să obținem datele, formatată ca "20xx-xx-xx".</param>
        /// <returns>Un JSON WeatherData din care vom prelua valorile de care avem nevoie.</returns>
        public WeatherData WeatherForCity(string city,string date)
        {
            Coordinates[] coordinates = _geocodingLoc.GetLocationCoord(city);

            return _weather.GetWeatherData(coordinates[0].Latitude, coordinates[0].Longitude,date);
        }


    }

}
