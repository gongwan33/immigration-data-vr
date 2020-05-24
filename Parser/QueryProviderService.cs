using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarGraph.VittorCloud;
using UnityEngine;


public class QueryProviderService : IQueryProviderService
{
    List<MigrationData> data;
    private Countries countries;
    public QueryProviderService(List<MigrationData> data) {
        this.data = data;

        countries = new Countries(
                            new Dictionary<string, Color>() {
                                        { "Australia", Color.green},
                                        { "United States of America", Color.red },
                                        { "Fiji", Color.blue },
                                        { "United Kingdom", Color.yellow },
                                        { "Cook Islands", Color.cyan },
                                        { "Samoa", Color.gray },
                                        { "Thailand", Color.magenta },
                                        { "India", Color.white },
                                        { "Indonesia", new Color(0.8f,0.5f,0.5f) },
                                        { "Japan", new Color(0.5f,0.8f,0.5f) },
                                        { "Oceania", new Color(0.5f,0.5f,0.8f) },
                                        { "Asia", new Color(0.3f,0.3f,0.8f) },
                                        { "Europe", new Color(0.8f,0.1f,0.4f) },
                                        { "Americas", new Color(0.1f,0.9f,0.8f) },
                                        { "Africa and the Middle East", new Color(0.8f,0.7f,0.1f) }
                            } 
        );
    }

    public List<BarGraphDataSet> GetBarDataByYear(int year)
    {
        return data.Where(b => b.assessedDate > new DateTime(year, 1, 1) && b.assessedDate < new DateTime(year, 12, 31) && !b.fromCountry.Equals("Total"))
                    .GroupBy(g => g.fromCountry)
                            .Select(c => new BarGraphDataSet {
                                                                GroupName = c.First().fromCountry, 
                                                                barColor = countries.GetCountryColour(c.First().fromCountry), 
                                                                barMaterial = null, 
                                                                ListOfBars = c.Where(w => w.fromCountry.Equals(c.First().fromCountry))
                                                                                .GroupBy(i => i.travelPurpose)
                                                                                   .Select(s => 
                                                                                                new XYBarValues 
                                                                                                                { XValue = s.First().travelPurpose, YValue = s.Sum(t => t.numberOfArrivals) }).ToList()
        }).ToList();
    }



    /**
     * Not used
     * **/
    public BarGraphDataSet GetCountryBreakUpByYear(string country, DateTime yearStart, DateTime yearEnd) {
        var countryWiseBreakUp = data.FindAll(c => c.fromCountry.Equals(country));
        var travelPurposeByRange = countryWiseBreakUp.GroupBy(a => a.travelPurpose).Select(c => new XYBarValues { XValue = c.First().travelPurpose, YValue= c.Sum(s => s.numberOfArrivals) }).ToList();
        var dataSet = new BarGraphDataSet();
        dataSet.barColor = Color.red;
        dataSet.barMaterial = null;
        dataSet.GroupName = country;
        dataSet.ListOfBars = travelPurposeByRange;
        return dataSet;
    }
}

