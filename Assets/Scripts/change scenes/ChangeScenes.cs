using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{

    public void GotoMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

}
