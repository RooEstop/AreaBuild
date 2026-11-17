using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    //만약 테스트가 다 끝나면, FieldSettingData로 옮기는 것이 좋음
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

    public MapData GenerateFieldMap(MapData map, FieldSettingData fieldSetting)
    {
        System.Random random = new System.Random();
        int[] seed = new int[2] { random.Next(-10000, 10000), random.Next(-10000, 10000) };

        MapFunctions.MultiOctave(seed, map, map.width, map.height, scale, lacunarity, persistance, fieldSetting);

        return map;
    }

    public MapData SetBlockBit(MapData map)
    {
        ApplyBlockData(map.fieldMapArray, BlockDatabase.tileObjectData, "TileData.csv", zeroIsEmpty: false);
        ApplyBlockData(map.structureArray, BlockDatabase.structureObjectData, "StructureData.csv", zeroIsEmpty: true);
        return map;
    }

    private static void ApplyBlockData(int[] array, BlockObject[] database, string dbName, bool zeroIsEmpty)
    {
        // 등록 안 된 ID는 ID당 한 번만 경고 (칸마다 찍으면 콘솔이 가득 참)
        bool[] warned = new bool[database.Length];

        for (int i = 0; i < array.Length; i++)
        {
            int block = array[i];
            int id = BlockCodec.GetBlockID(block);

            if (zeroIsEmpty && id == 0) continue;        // 구조물: ID 0은 "없음"

            BlockObject data = database[id];
            if (string.IsNullOrEmpty(data.blockName))    // CSV에 없는 ID
            {
                if (!warned[id])
                {
                    Debug.LogWarning($"SetBlockBit: ID 0x{id:X2} is not in {dbName}");
                    warned[id] = true;
                }
                continue;
            }

            // DB 값(ID, 내구도, 경로 비용, 기본 상태) + 생성 시 이미 붙은 상태 비트(지붕, 자연 생성 등)
            array[i] = data.blockBit | (block & BlockCodec.statusMask);
        }
    }
}
