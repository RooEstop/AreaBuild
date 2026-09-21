using UnityEngine;
using UnityEngine.Tilemaps;

public class MapRenderer : MonoBehaviour
{
    [Header("Scene¿« Tilemap")]
    public Tilemap fieldTileMap;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RenderField(MapData map)
    {
        int width = map.width;
        int height = map.height;
        Vector3Int[] tilePosition = new Vector3Int[width * height];
        TileBase[] tile = new TileBase[width * height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int index = y * width + x;
                int tileBit = map.fieldMapArray[BlockCodec.GetIndex(x, y, width)];
                int tileID = BlockCodec.GetBlockID(tileBit);

                tilePosition[index] = new Vector3Int(x, -y, 0);

                if (BlockDatabase.tileTexture[tileID] == null)
                    Debug.Log($"MapFunctions: Render Fail. No Texture Matched");

                tile[index] = BlockDatabase.tileTexture[tileID];

            }
        }
        fieldTileMap.SetTiles(tilePosition, tile);
    }
}
