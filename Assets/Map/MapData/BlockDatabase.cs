using UnityEngine;
using System.IO;
using System.ComponentModel;
using System;

public struct TileObject
{
    public int tileBit;
    public string tileName;
}

public struct StructureObject
{
    public int structureBit;
    public string structureName;
}

public static class BlockDatabase
{
    public static TileObject[] tileObjectData = new TileObject[256];
    public static StructureObject[] structureObjectData = new StructureObject[256];

    /// <summary>
    /// Initialize Block Database by reading .CSV file.
    /// </summary>
    public static void InitDatabase()
    {
        string tileDataFileName = "BlockData.csv";
        //string structureDataFileName = 

        ReadCSV(tileDataFileName);

        Debug.Log("Block Data Base Initialized.");
    }

    /// <summary>
    /// Find .csv file in Streaming Asset and copy data to TIle/Structure array.
    /// </summary>
    /// <param name="fileName"> File name to find </param>
    public static void ReadCSV( string fileName)
    {
        string directory = Application.streamingAssetsPath;
        string filePath = Path.Combine(directory, fileName);

        if (File.Exists(filePath))
        {
            using(StreamReader streamReader = new StreamReader(filePath))
            {
                streamReader.ReadLine();

                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] csvData = line.Split(",");
                    int index = Convert.ToInt32(csvData[0], 16);
                    if (csvData[4] == "") continue;
                    else tileObjectData[index].tileName = csvData[4];

                    tileObjectData[index].tileBit |= Convert.ToInt32(csvData[0], 16);
                    tileObjectData[index].tileBit |= Convert.ToInt32(csvData[1], 16) << 8;
                    tileObjectData[index].tileBit |= Convert.ToInt32(csvData[2], 16) << 20;
                    tileObjectData[index].tileBit |= Convert.ToInt32(csvData[3], 16) << 24;
                }
            }
        }
    }
}