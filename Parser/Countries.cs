using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Countries
{
    public Dictionary<string, Color> countryColour;
  
    public Countries(Dictionary<string, Color> countryColour) {
        this.countryColour = countryColour;
    }

    public Color GetCountryColour(string country) {
        return countryColour.FirstOrDefault(c => c.Key.Equals(country)).Value;
    }
}
