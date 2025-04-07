using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    [SerializeField] GameObject[] harts;
    public int lives = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReportPlayerHit()
    {

        lives--;

        for (int i = 0; i < harts.Length; i++)
        {

            if (i < lives)
            {
                harts[i].SetActive(true);
            }
            else
            {
                harts[i].SetActive(false);
            }

        }


        /* if (lives <= 0)
        {
            SceneManager.LoadScene("EndScreen");
         } */

    }
}
