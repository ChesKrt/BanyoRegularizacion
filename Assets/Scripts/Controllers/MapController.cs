using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapController : MonoBehaviour
{
    public static MapController Instance;

    public List<Vector2Int> mapSizes;
    public List<Vector2Int> mapOrigin;
    public Tile[] tiles;

    [Header("Obstacles Set")]
    public int obstacleAmount;
    public Tile obstacleTile;
    public Vector2Int obstacleHeights;
    public int obstacleLenght;

    private void Awake()
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
    }

    void Start()
    {
        GameObject grid = new GameObject();
        grid.name = "Grid";

        grid.AddComponent<Grid>();

        Grid gridComponent = grid.GetComponent<Grid>();
        gridComponent.cellLayout = GridLayout.CellLayout.Rectangle;
        gridComponent.cellSize = new Vector3(0.64f, 0.64f, 1);

        GameObject tileMap = new GameObject();
        tileMap.name = "TileMap";


        tileMap.AddComponent<Tilemap>();
        tileMap.AddComponent<TilemapRenderer>();
        tileMap.AddComponent<TilemapCollider2D>();

        TilemapRenderer tileMapRender = tileMap.GetComponent<TilemapRenderer>();
        tileMapRender.sortOrder = TilemapRenderer.SortOrder.TopRight;

        tileMap.transform.parent = grid.transform;

        Tilemap map = tileMap.GetComponent<Tilemap>();
        GenerateStage(map);
    }


    private void GenerateStage(Tilemap map)
    {
        Map newMap = new Map("Bosque", mapOrigin[0], mapSizes[0], map, obstacleHeights, obstacleLenght);
        List<Vector3Int> coordinates = newMap.GenerateGroundCoordinates();
        newMap.Render(tiles[0], coordinates);
        for (int i = 0; i < obstacleAmount; i++)
        {
            List<Vector3Int> coordPlatforms = newMap.GeneratePlataforms();
            List<Vector3Int> coordObstacles = newMap.GenerateGroundObstacles();
            newMap.Render(obstacleTile, coordObstacles);
            newMap.Render(obstacleTile, coordPlatforms);
        }
    }

}
