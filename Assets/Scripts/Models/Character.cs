using UnityEngine;

public class Character
{
    private int _health;
    private float _velocity_movement;
    private float _damage_hit;
    private float _jump_height;
    private float _cooldown;


    public int Health
    {
        get
        {
            return _health;
        }

        set
        {
            if(value < 0)
            {
                _health = 0;
            }
            else
            {
                _health = value;
            }
        }
    }

    public float Velocity_Movement
    {
        get
        {
            return _velocity_movement;
        }
        set
        {
            _velocity_movement = value;
        }
    }

    private float Damage_Hit
    {
        get
        {
            return _damage_hit; 
        }
        set
        {
            _damage_hit = value;
        }
    }

    public float Jump_Height
    {
        get
        {
            return _jump_height;
        }
        set
        {
            _jump_height = value;
        }
    }

    public float Cooldown
    {
        get
        {
            return _cooldown;
        }
        set
        {
            _cooldown = value;
        }
    }
}
