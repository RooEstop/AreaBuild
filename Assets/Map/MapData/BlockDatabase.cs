using UnityEngine;
using System.IO;
using System.ComponentModel;
using System;
using UnityEngine.Tilemaps;

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

    public static TileBase[] tileTexture = new TileBase[256];
    public static TileBase[] structureTexture = new TileBase[256];

    /// <summary>
    /// Initialize Block Database by reading .CSV file.
    /// </summary>
    public static void InitDatabase()
    {
        string tileDataFileName = "TileData.csv";
        //string structureDataFileName = 

        ReadCSV(tileDataFileName);
        InitTileBase();

        Debug.Log("Block Data Base Initialized.");
    }

    public static void InitTileBase()
    {
        for (int i = 0; i < 256; i++) 
        {
            if (string.IsNullOrEmpty(tileObjectData[i].tileName))   continue;
                
            tileTexture[i] = Resources.Load<TileBase>(tileObjectData[i].tileName);
        }
    }

    /// <summary>
    /// Find .csv file in Streaming Asset and copy data to TIle/Structure array.
    /// </summary>
    /// <param name="fileName"> File name to find </param>
    public static void ReadCSV(string fileName)
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
                    if (csvData[4] == "") continue; //need to be fixed when csv is complete.
                    else tileObjectData[index].tileName = csvData[4];


                    tileObjectData[index].tileBit = BlockCodec.BlockEncode(Convert.ToInt32(csvData[0], 16),
                                                                            Convert.ToInt32(csvData[1], 16),
                                                                            Convert.ToInt32(csvData[2], 16),
                                                                            Convert.ToInt32(csvData[3], 16));
                }
            }
        }
    }
}