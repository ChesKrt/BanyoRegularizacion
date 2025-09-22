using UnityEngine;

public enum Ability { dash, run, double_jump, wall_jump }

public class Player : Character
{
    public Ability ability; 
    public Inventory inventory;
    public Stats stadistics;

    public void PlayerMovement() {}
}
