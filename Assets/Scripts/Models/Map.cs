using UnityEngine;

public class Map
{
  public string name;
  public Vector2Int originCoordinate;
  public Vector2Int size;

   public Map(string name, Vector2Int originCoordinate, Vector2Int size)
   {
      this.name = name;
      this.originCoordinate = originCoordinate;
      this.size = size;
   } 
}
