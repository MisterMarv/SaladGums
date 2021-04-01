using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuEvents : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
