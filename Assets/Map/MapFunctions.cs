using Unity.Mathematics;

public class MapFunctions
{
    /// <summary>
    /// Make noise for Map Generating
    /// </summary>
    /// <param name="seed"> Random seed to generate noise </param>
    /// <param name="array"> Map array to handle </param>
    /// <param name="width"> Map width </param>
    /// <param name="height"> Map height </param>
    /// <param name="scale"> Scale for noise </param>
    /// <param name="lacunarity"> determine how noise is density </param>
    /// <param name="persistance"> determine effect of SubOctv </param>
    /// <param name="fieldSetting"> Threshold for River / Land / Mountain </param>
    public static void MultiOctave(int[] seed, MapData map, int width, int height, float scale, float lacunarity, float persistance, FieldSettingData fieldSetting)
    {
        float maxOctv = 1f + (persistance) + (persistance * persistance);
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++)
            {
                float2 loc1 = new float2((x + seed[0]) * (1f / scale), (y + seed[1]) * (1f / scale));
                float2 loc2 = new float2((x + seed[0]) * (1f / scale) * lacunarity, (y + seed[1]) * (1f / scale) * lacunarity);
                float2 loc3 = new float2((x + seed[0]) * (1f / scale) * (lacunarity * lacunarity), (y + seed[1]) * (1f / scale) * (lacunarity * lacunarity));

                float subOctv1 = noise.snoise(loc1);
                float subOctv2 = noise.snoise(loc2) * math.pow(persistance, 1);
                float subOctv3 = noise.snoise(loc3) * math.pow(persistance, 2);
                float multiOctv = subOctv1 + subOctv2 + subOctv3;

                multiOctv *= (1 / maxOctv);

                int index = BlockCodec.GetIndex(x, y, width);

                //Setting Block ID bit (0x-- ---- 00)
                int blockID;
                if (multiOctv < fieldSetting.waterThreshold)      blockID = BlockCodec.oceanCode + fieldSetting.defaultOcean;  //Ocean
                else if (multiOctv < fieldSetting.dirtThreshold)  blockID = BlockCodec.dirtCode + fieldSetting.defaultDirt;   //Land(Plain)
                else                                              blockID = BlockCodec.stoneCode + fieldSetting.defaultStone;  //Stone

                map.fieldMapArray[index] = BlockCodec.BlockEncode(blockID);

                // Setting Status bit (0x00 ---- --)
                // And set mountain - structure array
                if (multiOctv > fieldSetting.mountainThreshold)
                {
                    map.fieldMapArray[index] |= BlockCodec.upperBlockExistCode;  //Mountain

                    blockID = BlockCodec.stoneMountainCode;
                    map.structureArray[index] = BlockCodec.BlockEncode(blockID);  //Mountain
                }
            }
        }
    }

    public static int[] RandomCoordinate(int seed)
    {
        System.Random random = new System.Random(seed);
        int[] randomLoc = new int[2] { random.Next(-1_000_000, 1_000_000), random.Next(-1_000_000, 1_000_000) };
        return randomLoc;
    }

}


