using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("노이즈 세부 설정")]
    public float scale = 30f;
    [Header("노이즈 세부 설정")]
    public float lacunarity = 2f;
    [Header("노이즈 세부 설정")]
    public float persistance = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public MapData FieldGenerate(MapData map, FieldSettingData fieldSetting)
    {
        System.Random random = new System.Random();
        int[] seed = new int[2] { random.Next(-10000, 10000), random.Next(-10000, 10000) };

        MapFunctions.MultiOctave(seed, map.fieldMapArray, map.width, map.height, scale, lacunarity, persistance, fieldSetting);

        return map;
    }
}
