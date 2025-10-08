using UnityEngine;
using System.Collections.Generic;

public enum Ability { dash, run, double_jump, wall_jump }

public class Player : Character
{
    public static Player Instance { get; private set; }

    private List<Ability> _ability;
    private Dictionary<string, Inventory> _inventory = new Dictionary<string, Inventory>();
    private Stats _playerStats;

    public Player(int health, float velocity_Movement, float jump_height)
    {
        this.Health = health;
        this.Velocity_Movement = velocity_Movement;
        this.Jump_Height = jump_height;
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

    public void PlayerMovement(Transform transform, Rigidbody2D rigidbody2D)
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.transform.position += new Vector3(1f, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.transform.position += new Vector3(-1f, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.AddForce(Vector2.up * Jump_Height, ForceMode2D.Impulse);
        }
    }

    public void AddNewAbility(Ability newAbility)
    {
        _ability.Add(newAbility);
    }
}
