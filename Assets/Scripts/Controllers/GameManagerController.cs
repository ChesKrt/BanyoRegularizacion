using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerController : MonoBehaviour
{
    public static GameManagerController Instance { get; set; }
    int sceneNumber = 0;

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
        sceneNumber++;
        SceneManager.LoadScene(sceneNumber);
    }

}
