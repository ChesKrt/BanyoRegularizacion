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
    public Tile[] obstacleTiles;
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
        gridComponent.cellSize = new Vector3(0.18f, 0.18f, 1);

        GameObject tileMap = new GameObject();
        tileMap.name = "TileMap";


        tileMap.AddComponent<Tilemap>();
        tileMap.AddComponent<TilemapRenderer>();
        tileMap.AddComponent<TilemapCollider2D>();
        tileMap.AddComponent<CompositeCollider2D>();

        Rigidbody2D rigidbody2D = tileMap.GetComponent<Rigidbody2D>();

        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        rigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rigidbody2D.interpolation = RigidbodyInterpolation2D.Interpolate;
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;

        TilemapCollider2D tilemapCollider = tileMap.GetComponent<TilemapCollider2D>();
        tilemapCollider.compositeOperation = Collider2D.CompositeOperation.Merge;

        TilemapRenderer tileMapRender = tileMap.GetComponent<TilemapRenderer>();
        tileMapRender.sortOrder = TilemapRenderer.SortOrder.TopRight;

        tileMap.transform.parent = grid.transform;

        Tilemap map = tileMap.GetComponent<Tilemap>();


        for (int i = 0; i < mapSizes.Count; i++)
        {
            GenerateStage(map, i);
        }

    }


    private void GenerateStage(Tilemap map, int origin = 0)
    {
        Map newMap = new Map("Bosque", mapOrigin[origin], mapSizes[origin], map, obstacleHeights, obstacleLenght);
        List<Vector3Int> coordinates = newMap.GenerateGroundCoordinates();

        CollectableController collectableController = FindAnyObjectByType<CollectableController>();
        newMap.Render(tiles[origin], coordinates);
        for (int i = 0; i < obstacleAmount; i++)
        {
            List<Vector3Int> coordPlatforms = newMap.GeneratePlataforms();
            List<Vector3Int> coordObstacles = newMap.GenerateGroundObstacles();
            newMap.Render(obstacleTiles[origin], coordObstacles);
            newMap.Render(obstacleTiles[origin], coordPlatforms);
        }

        List<Vector3Int> objectcoordinates = newMap.SpawnObjects();
        collectableController.SpawnObjects(map, objectcoordinates);
    }


}
