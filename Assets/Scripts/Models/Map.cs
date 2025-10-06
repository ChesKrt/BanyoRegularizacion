using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;


public class Map
{
    private string _name;
    private Vector2Int _originCoordinate;
    private Vector2Int _size;
    private Tilemap _tilemap;
    private Vector2Int yRandomRange;
    private int xLenght;

    public Map(string name, Vector2Int originCoordinate, Vector2Int size, Tilemap tilemap, Vector2Int yRandomRange, int xLenght)
    {
        this._name = name;
        this._originCoordinate = originCoordinate;
        this._size = size;
        this._tilemap = tilemap;
        this.yRandomRange = yRandomRange;
        this.xLenght = xLenght;
    }

    public List<Vector3Int> GenerateGroundCoordinates()
    {
        List<Vector3Int> groundCoordinates = new List<Vector3Int>();

        for (int x = _originCoordinate.x; x < _size.x + _originCoordinate.x; x++)
        {
            groundCoordinates.Add(new Vector3Int(x, _originCoordinate.y));
        }
        return groundCoordinates;
    }

    public List<Vector3Int> GenerateGroundObstacles()
    {
        List<Vector3Int> obstacleCoord = new List<Vector3Int>();
        int initPosX = Random.Range(0, _size.x);
        int limitY = 0;

        for (int x = initPosX + _originCoordinate.x; x < (initPosX + _originCoordinate.x) + xLenght; x++)
        {
            limitY = Random.Range(yRandomRange.x, yRandomRange.y);

            for (int y = _originCoordinate.y; y < limitY + _originCoordinate.y; y++)
            {
                obstacleCoord.Add(new Vector3Int(x, y, 0));
            }
        }

        return obstacleCoord;
    }


    public List<Vector3Int> GeneratePlataforms()
    {
        List<Vector3Int> platformsCoord = new List<Vector3Int>();
        int initPosX = Random.Range(0, _size.x);
        int initPosY = Random.Range(yRandomRange.y + 2, _size.y);

        for (int x = initPosX + _originCoordinate.x; x < (initPosX + _originCoordinate.x) + xLenght; x++)
        {
            platformsCoord.Add(new Vector3Int(x, initPosY + _originCoordinate.y, 0));
        }
        return platformsCoord;
    }

    public List<Vector3Int> GenerateCoordinates()
    {
        List<Vector3Int> newCoordinates = new List<Vector3Int>();

        for (int x = _originCoordinate.x; x < _size.x + _originCoordinate.x; x++)
        {
            for (int y = _originCoordinate.y; y < _size.y + _originCoordinate.y; y++)
            {
                newCoordinates.Add(new Vector3Int(x, y, 0));
            }
        }
        return newCoordinates;
    }

    public void Render(Tile tile, List<Vector3Int> coordinates)
    {
        for (int i = 0; i < coordinates.Count; i++)
        {
            _tilemap.SetTile(coordinates[i], tile);
        }
    }

}
