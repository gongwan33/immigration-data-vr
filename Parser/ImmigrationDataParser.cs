using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarGraph.VittorCloud;
using UnityEngine;
using System.Text.RegularExpressions;

class ImmigrationDataParser
{
    List<MigrationData> parsedData = new List<MigrationData>();

    private string[] parseTextAsset(TextAsset ft)
    {
        string fs = ft.text;
        string[] fLines = Regex.Split(fs, "\n|\r|\r\n");

        return fLines;
    }

    public ImmigrationDataParser(TextAsset dat)
    {
        string[] lines = parseTextAsset(dat);

        var lineCount = 0;

        foreach (string line in lines)
        {
            if (lineCount != 0)
            {
                String[] splitLine = line.Split(',');
                var data = new MigrationData();
                var isDateParsed = DateTime.TryParse(splitLine[0], out data.assessedDate);
                if (!isDateParsed)
                {
                    continue;
                }
                data.fromCountry = splitLine[6];
                data.travelPurpose = splitLine[9];
                var isIntPared = int.TryParse(splitLine[10], out data.numberOfArrivals);
                if (!isIntPared)
                {
                    continue;
                }
                parsedData.Add(data);
            }

            lineCount++;
        }
        Console.WriteLine(lineCount);
    }

    public List<BarGraphDataSet> GetBarData(int year)
    {


        var service = new QueryProviderService(parsedData);
        //service.GetCountryBreakUpByYear("Asia", new DateTime(2020, 01, 01), new DateTime(2020, 03, 01));
        var res = service.GetBarDataByYear(year);

        return res;
    }
}

