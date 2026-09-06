using UnityEditor.Rendering;
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
        MapFunctions.DrawField(map, fieldTileMap);
    }
}
