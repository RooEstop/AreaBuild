using UnityEngine;
using Unity.Mathematics;

public class MapFunctions
{
    public static int[,] FieldGenerator(int[,] field, int seed)
    {


        return field;
    }

    //summary
    //Generate Multi Octv value in Array
    //Scale : To make value smooth
    //Lacunarity : Decide how much wave flat
    //Persistance : Decide how much wave affect
    public static void MulitOctave(int[] seed, int[] array, int width, int height, float scale, float lacunarity, float persistance, FieldSettingData fieldSetting)
    {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++)
            {
                float2 loc1 = new float2(x + seed[0] * scale, y + seed[1] * scale);
                float2 loc2 = new float2(x + seed[0] * scale * lacunarity, y + seed[1] * scale * lacunarity);
                float2 loc3 = new float2(x + seed[0] * scale * (lacunarity * lacunarity), y + seed[1] * scale * (lacunarity * lacunarity));

                float subOctv1 = noise.snoise(loc1);
                float subOctv2 = noise.snoise(loc2) * math.pow(persistance, 1);
                float subOctv3 = noise.snoise(loc3) * math.pow(persistance, 2);
                float multiOctv = subOctv1 + subOctv2 + subOctv3;

                int index = MapDataHandler.GetIndex(x, y, width);

                //Setting Block ID bit (0x-- ---- 00)
                if (multiOctv < fieldSetting.waterThreshold)      array[index] |= 0x00 + fieldSetting.defaultOcean;  //Ocean
                else if (multiOctv < fieldSetting.dirtThreshold)  array[index] |= 0x10 + fieldSetting.defaultDirt;   //Land(Plain)
                else if (multiOctv < fieldSetting.stoneThreshold) array[index] |= 0x20 + fieldSetting.defaultStone;  //Stone

                //Setting Status bit (0x00 ---- --)
                if (multiOctv > fieldSetting.mountainThreshold) array[index] |= 0x01000000;  //Mountain
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


