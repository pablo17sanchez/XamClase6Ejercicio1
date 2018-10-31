using System;
using System.Collections.Generic;
using System.Text;

namespace App23.Entidades
{
  public  class Condition
    {

        public string text { get; set; }
        public string icon { get; set; }
        public string IconUrl
        {
            get
            {
                return $"http:{icon}";
            }
        }


    }
}
