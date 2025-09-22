using UnityEngine;
using System.Collections.Generic;

public class Inventory
{
    public Map map;
    public List<Collection> weapons;
    public List<Collection> abilities;
    public List<Collection> powerUps;
    public Dictionary <string, int> death_enemies = new Dictionary<string, int>();
}
