using UnityEngine;
using System.Collections.Generic;

public class Inventory
{
    private string _name;
    private List<Collection> _objectList;

    public Inventory(string name, List<Collection> objectList)
    {
        this._name = name;
        this._objectList = objectList;
    }
}
