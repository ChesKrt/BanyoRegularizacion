using UnityEngine;
using System.Collections.Generic;

public enum Ability { dash, run, double_jump, wall_jump }

public class Player : Character
{
    public static Player Instance {get; private set;}

    private List<Ability> _ability; 
    private Dictionary<string, Inventory> _inventory = new Dictionary<string, Inventory>();
    private Stats _playerStats;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayerMovement() {}

    public void AddNewAbility(Ability newAbility)
    {
        _ability.Add(newAbility);
    }
}
