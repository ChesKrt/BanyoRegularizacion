using UnityEngine;
using System.Collections.Generic;

public class Inventory
{
    public string name;
    public List<Collection> objectList;

    public Inventory(string name, List<Collection> objectList)
    {
        this.name = name;
        this.objectList = objectList;
    }
}
