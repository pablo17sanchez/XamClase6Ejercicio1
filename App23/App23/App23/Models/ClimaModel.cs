using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace App23.Models
{
    public class ClimaModel
    {

        [PrimaryKey, AutoIncrement]
        public int Climaid { get; set; }

        public String City { get; set; }
        public String Country { get; set; }
        public string celcius { get; set; }

        public string CelciusText { get; set; }

     
        public string fahrenheit { get; set; }

        public string FahrenheitText { get; set; }
   
     
        public bool isday { get; set; }

        
        public string lastupdated { get; set; }

        public String Urlicon { get; set; }

    }


}

