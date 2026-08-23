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
    public static void MulitOctave(int[] seed, int[,] array, float scale, float lacunarity, float persistance, FieldSettingData fieldSetting)
    {
        for (int x = 0; x < array.GetLength(0); x++) {
            for (int y = 0; y < array.GetLength(1); y++)
            {
                float2 loc1 = new float2(x + seed[0] * scale, y + seed[1] * scale);
                float2 loc2 = new float2(x + seed[0] * scale * lacunarity, y + seed[1] * scale * lacunarity);
                float2 loc3 = new float2(x + seed[0] * scale * (lacunarity * lacunarity), y + seed[1] * scale * (lacunarity * lacunarity));

                float subOctv1 = noise.snoise(loc1);
                float subOctv2 = noise.snoise(loc2) * math.pow(persistance, 1);
                float subOctv3 = noise.snoise(loc3) * math.pow(persistance, 2);
                float multiOctv = subOctv1 + subOctv2 + subOctv3;

                //Setting Block ID bit (0x-- ---- 00)
                if (multiOctv < fieldSetting.waterThreshold)      array[x, y] |= 0x00 + fieldSetting.defaultOcean;  //Ocean
                else if (multiOctv < fieldSetting.dirtThreshold)  array[x, y] |= 0x10 + fieldSetting.defaultDirt;   //Land(Plain)
                else if (multiOctv < fieldSetting.stoneThreshold) array[x, y] |= 0x20 + fieldSetting.defaultStone;  //Stone

                //Setting Status bit (0x00 ---- --)
                if (multiOctv > fieldSetting.mountainThreshold) array[x, y] |= 0x01000000;  //Mountain
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


