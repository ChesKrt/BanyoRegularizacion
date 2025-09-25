using UnityEngine;

public class Map
{
  private string _name;
  private Vector2Int _originCoordinate;
  private Vector2Int _size;

   public Map(string name, Vector2Int originCoordinate, Vector2Int size)
   {
      this._name = name;
      this._originCoordinate = originCoordinate;
      this._size = size;
   } 
}
