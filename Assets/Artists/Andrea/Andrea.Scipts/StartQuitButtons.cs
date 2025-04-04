using UnityEngine;
using UnityEngine.SceneManagement;

public class StartQuitButtons : MonoBehaviour
{
    [SerializeField] GameObject panel;
    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void menuLoad()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void exitApplication()
    {
        Application.Quit();
    }
    
    public void credditsON()
    {
        panel.SetActive(true);
    }

    public void credditsOFF()
    {
        panel.SetActive(false);
    }
}
