using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void ChangeToLevel()
    {
        GameManagerController.Instance.ChangeNextScene();
    }

}
