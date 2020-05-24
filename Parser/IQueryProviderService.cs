using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarGraph.VittorCloud;

public interface IQueryProviderService
{
    BarGraphDataSet GetCountryBreakUpByYear(string country, DateTime yearStart, DateTime yearEnd);

    List<BarGraphDataSet> GetBarDataByYear(int year);
}

