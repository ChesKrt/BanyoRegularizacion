using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerController : MonoBehaviour
{
    public static GameManagerController Instance { get; set; }
    private int _sceneNumber = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    public void ChangeNextScene()
    {
        _sceneNumber++;
        SceneManager.LoadScene(_sceneNumber);
    }

}
