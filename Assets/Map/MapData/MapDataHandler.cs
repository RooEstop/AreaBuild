using UnityEngine;

public static class MapDataHandler
{
    //Mask value to get Block Info
    public const int blockIDMask = 0x000000FF;
    public const int durabilityMask = 0x000FFF00;
    public const int pathCostMask = 0x00F00000;
    public const int statusMask = 0x7F000000;

    public static int GetBlockID(int block)
    {
        Debug.Log($"Block ID : {block & blockIDMask}");
        return (block & blockIDMask);
    }

    public static int GetDurability(int block)
    {
        Debug.Log($"Block ID : {(block & durabilityMask) >> 8} ");
        return ((block & durabilityMask) >> 8);
    }

    public static int GetStatus(int block)
    {
        Debug.Log($"Block ID : {(block & statusMask) >> 24} ");
        return ((block & statusMask) >> 24);
    }

    /// <summary>
    /// Get index from x, y coordinate.
    /// </summary>
    /// <param name="x"></param> x coordinate
    /// <param name="y"></param> y coordinate
    /// <param name="w"></param> width of map
    /// <returns></returns> Return Index appropriate for input coordinate
    public static int GetIndex(int x, int y, int w) { return (y * w) + x; }
}
