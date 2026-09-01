using UnityEngine;


public static class MapDataHandler
{
    //Mask value to get Block Info
    const int blockIDMask = 0x000000FF;
    const int durabilityMask = 0x00FFFF00;
    const int statusMask = 0x7F000000;

    public static int GetBlockID(int block)
    {
        Debug.Log($"Block ID : {block | blockIDMask}");
        return (block | blockIDMask);
    }

    public static int GetDurability(int block)
    {
        Debug.Log($"Block ID : {(block | durabilityMask) >> 8} ");
        return ((block | durabilityMask) >> 8);
    }

    public static int GetStatus(int block)
    {
        Debug.Log($"Block ID : {(block | statusMask) >> 24} ");
        return ((block | statusMask) >> 24);
    }
}
