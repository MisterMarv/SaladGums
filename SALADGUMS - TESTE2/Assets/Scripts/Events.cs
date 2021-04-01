using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
   //Replay Level

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Quit game

    public void BackGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
