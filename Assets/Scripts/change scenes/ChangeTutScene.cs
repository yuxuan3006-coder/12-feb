using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeTutScene : MonoBehaviour
{
public void GotoTutScene()
    {
        SceneManager.LoadScene("TutScene");
    }
}
