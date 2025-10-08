using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    public static PlayerController instance { get; private set;}
    public Player player;

    public int health;
    public float velocity_Movement, jump_Height;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);

            player = new Player(health, velocity_Movement, jump_Height);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        player.PlayerMovement(this.transform, _rigidbody2D);
    }
}
