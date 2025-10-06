using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private PlayerController instance;
    public Player player;
    public PlayerController Instance
    {
        get
        {
            if (instance != null)
            {
                Instance.instance = this;
                player = new Player();
            }
                return Instance;
        }
    }
}
