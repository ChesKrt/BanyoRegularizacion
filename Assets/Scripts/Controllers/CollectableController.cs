using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem.iOS;

public class CollectableController : MonoBehaviour
{
    public List<Vector2Int> collectionableOrigin;
    public GameObject[] collectables;
    public int amount;

    private void Start()
    {
        Collection sword = new Collection("Wood Sword", 10, collectables[0]);



    }

    public void SpawnObjects(Tilemap tilemap, List<Vector3Int> weaponsCoor)
    {
        for (int coordinates = weaponsCoor.Count - 1; coordinates > 0; coordinates--)
        {
            int initialCoor = Random.Range(0, coordinates + 1);
            Vector3Int temp = weaponsCoor[coordinates];
            weaponsCoor[coordinates] = weaponsCoor[initialCoor];
            weaponsCoor[initialCoor] = temp;
        }

        int inPlace = 0;

        for (int i = 0; i < weaponsCoor.Count && inPlace < amount; i++)
        {
            Vector3 worldPosition = tilemap.GetCellCenterWorld(weaponsCoor[i]);
            if (!tilemap.HasTile(weaponsCoor[i]))
            {
                GameObject prefab = collectables[Random.Range(0, collectables.Length)];
                Instantiate(prefab, worldPosition, Quaternion.identity);
            }
            
            inPlace++;
        }
    }

}
