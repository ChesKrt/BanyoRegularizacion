using UnityEngine;
using System.Collections.Generic;

public enum Ability { dash, run, double_jump, wall_jump }

public class Player : Character
{
    public static Player Instance {get; private set;}

    private List<Ability> _ability; 
    private Dictionary<string, Inventory> _inventory = new Dictionary<string, Inventory>();
    private Stats _playerStats;

    public Player ()
    {

    }

    public List<Ability> Abilities
    {
        get { return _ability; }
    }

    public Dictionary<string, Inventory> Inventory
    {
        get { return _inventory; }
    }

    public Stats Stat
    {
        get { return _playerStats; }
    }

    public void PlayerMovement() {}

    public void AddNewAbility(Ability newAbility)
    {
        _ability.Add(newAbility);
    }
}
