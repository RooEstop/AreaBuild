using System;
using UnityEngine;

[Serializable]
public class MapData
{
    //Map Size = Width * Height;
    public int width;
    public int height;

    //Map Data Array
    public int[,] worldMapArray;    //World Map
    public int[,] fieldArray;       //Player Field
    public int[,] structureArray;   //Structure on Field

    //Generator
    public MapData(int w, int h)
    {
        width = w;
        height = h;
        worldMapArray = new int[width, height];
        fieldArray = new int[width, height];
        structureArray = new int[width, height];
    }
}
