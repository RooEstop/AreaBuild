using UnityEngine;
using System.IO;
using System;
using UnityEngine.Tilemaps;

public struct BlockObject
{
    public int blockBit;
    public string blockName;
}

public static class BlockDatabase
{
    public static BlockObject[] tileObjectData = new BlockObject[256];
    public static BlockObject[] structureObjectData = new BlockObject[256];

    public static TileBase[] tileTexture = new TileBase[256];
    public static TileBase[] structureTexture = new TileBase[256];

    /// <summary>
    /// Initialize Block Database by reading .CSV file.
    /// </summary>
    public static void InitDatabase()
    {
        string tileDataFileName = "TileData.csv";
        string structureDataFileName = "StructureData.csv";

        ReadCSV(tileDataFileName, tileObjectData);
        ReadCSV(structureDataFileName, structureObjectData);
        InitTileBase();
        InitStructureBase();

        Debug.Log("Block Data Base Initialized.");
    }

    public static void InitTileBase()
    {
        for (int i = 0; i < 256; i++) 
        {
            if (string.IsNullOrEmpty(tileObjectData[i].blockName))   continue;
                
            tileTexture[i] = Resources.Load<TileBase>(tileObjectData[i].blockName);
        }
    }

    public static void InitStructureBase()
    {
        for (int i = 0; i < 256; i++)
        {
            if (string.IsNullOrEmpty(structureObjectData[i].blockName)) continue;

            structureTexture[i] = Resources.Load<TileBase>(structureObjectData[i].blockName);
        }
    }

    /// <summary>
    /// Find .csv file in Streaming Asset and copy data to TIle/Structure array.
    /// </summary>
    /// <param name="fileName"> File name to find </param>
    public static void ReadCSV(string fileName, BlockObject[] objectList)
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
                    else objectList[index].blockName = csvData[4];

                    objectList[index].blockBit = BlockCodec.BlockEncode(Convert.ToInt32(csvData[0], 16),
                                                                            Convert.ToInt32(csvData[1], 16),
                                                                            Convert.ToInt32(csvData[2], 16),
                                                                            Convert.ToInt32(csvData[3], 16));
                }
            }
        }
    }
}