using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class CollectableController : MonoBehaviour
{
    public List<Vector2Int> collectionableOrigin;
    public GameObject[] collectables;

    private void Start()
    {
        Collection sword = new Collection("Wood Sword", 10, collectables[0]);

        sword.SpawnObject(collectionableOrigin[0]);

    }
}
