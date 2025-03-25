using UnityEngine;
using UnityEngine.SceneManagement;

public class StartQuitButtons : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void menuLoad()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void exitApplication()
    {
        Application.Quit();
    }
}
