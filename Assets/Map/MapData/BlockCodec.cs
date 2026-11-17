using UnityEngine;

public static class BlockCodec
{
    //Mask value to get Block Info
    public const int blockIDMask =    0x000000FF;
    public const int durabilityMask = 0x000FFF00;
    public const int pathCostMask =   0x00F00000;
    public const int statusMask =     0x7F000000;

    // Shift bit for encode
    public const int durabilityShift = 8;
    public const int pathCostShift =   20;
    public const int statusShift =     24;

    // Tile landscape code
    public const int oceanCode = 0x00;
    public const int dirtCode =  0x10;
    public const int stoneCode = 0x20;

    // Tile Status code
    public const int upperBlockExistCode =  0x40000000;
    public const int fertilityCode =        0x20000000;
    public const int speedCode =            0x10000000;
    public const int poisonCode =           0x08000000;
    public const int conductivityCode =     0x04000000;
    public const int floodabilityCode =     0x02000000;
    public const int flammabilityCode =     0x01000000;

    // Structure ID Bit
    public const int stoneMountainCode = 0x01;

    // Structure Status Code
    public const int naturalSpawnedCode = 0x20000000;
    public const int BlockingCode = 0x10000000;         // 0 -> Open, 1 -> Closed


    public static int GetBlockID(int block) => (block & blockIDMask);
    public static int GetDurability(int block) => ((block & durabilityMask) >> durabilityShift);
    public static int GetPathCost(int block) => ((block & pathCostMask) >> pathCostShift);
    public static int GetStatus(int block) => ((block & statusMask) >> statusShift);

    public static int BlockEncode(int blockID, int durability=0, int pathCost=0, int status=0)
    {
        int block = 0;
        block |= blockID & blockIDMask;
        block |= (durability << durabilityShift) & durabilityMask;
        block |= (pathCost << pathCostShift)     & pathCostMask;
        block |= (status << statusShift)         & statusMask;

        return block;
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
