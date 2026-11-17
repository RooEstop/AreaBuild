using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public MapData currentMapData;
    public FieldSettingData currentBiome;
    public MapGenerator mapGeneratorInstance;
    public MapRenderer mapRendererInstance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        currentMapData = new MapData(200, 200);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BlockDatabase.InitDatabase();
        MakeField();
        RenderField();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeField()
    {
        mapGeneratorInstance.GenerateFieldMap(currentMapData, currentBiome);
        mapGeneratorInstance.SetBlockBit(currentMapData);
    }

    void RenderField()
    {
        mapRendererInstance.RenderField(currentMapData);
        mapRendererInstance.RenderStructure(currentMapData);
    }
}
