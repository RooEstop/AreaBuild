using UnityEngine;
using System.IO;

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

    public static void InitDatabase()
    {
        string fileName = "BlockData.csv";

        using()

        Debug.Log("Block Data Base Initialized.");
    }
}