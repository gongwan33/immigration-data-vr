using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BarGraph.VittorCloud;

public class BarGraphDat : MonoBehaviour
{
    BarGraphGenerator _barGraphGenerator;
    ImmigrationDataParser _parser = new ImmigrationDataParser();

    public List<List<BarGraphDataSet>> appDataSet = new List<List<BarGraphDataSet>>();
    int[] _yearList = new int[] { 2018, 2019, 2020 };

    // Start is called before the first frame update
    void Start()
    {
        _barGraphGenerator = GetComponent<BarGraphGenerator>();

        foreach(int year in _yearList)
        {
            appDataSet.Add(_parser.GetBarData(year));
        }

        //if the exampleDataSet list is empty then return.
        if (appDataSet.Count == 0)
        {

            Debug.LogError("ExampleDataSet is Empty!");
            return;
        }

        _barGraphGenerator.GeneratBarGraph(appDataSet[appDataSet.Count -  1]);
    }

    public void updateBarYear(int year)
    {
        int idx = 0;

        for (int i = 0; i < _yearList.Length; i++)
        {
            if (_yearList[i] == year)
            {
                idx = i;
                break;
            }
        }

        _barGraphGenerator.GeneratBarGraph(appDataSet[idx]);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
