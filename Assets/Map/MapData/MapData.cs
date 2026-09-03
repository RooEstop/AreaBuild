using NUnit.Framework.Constraints;
using System;
using UnityEngine;

[Serializable]
public class MapData
{
    //Map Size = Width * Height;
    public int width;
    public int height;

    //Map Data Array
    public int[] worldMapArray;    //World Map
    public int[] fieldMapArray;       //Player Field
    public int[] structureArray;   //Structure on Field

    /// <summary>
    /// Generator.
    /// </summary>
    /// <param name="w"> Width of map </param>
    /// <param name="h"> Height of map </param>
    public MapData(int w, int h)
    {
        width = w;
        height = h;

        int mapSize = width * height;
        worldMapArray = new int[mapSize];
        fieldMapArray = new int[mapSize];
        structureArray = new int[mapSize];
    }
}
