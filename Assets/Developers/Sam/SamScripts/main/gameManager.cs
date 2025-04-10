using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    [SerializeField] GameObject[] harts;
    public int lives = 5;

    [SerializeField] private TextMeshProUGUI timePoints;
    private float timeNum;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPrefs.SetFloat("timeScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("StartScreen");

        }

        timeNum = Mathf.Floor(Time.time);

        PlayerPrefs.SetFloat("timeScore", timeNum);

        string output = "" + timeNum;

        output = output.PadLeft(5, '0');

        timePoints.text = output;
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


        if (lives <= 0)
        {
           //SceneManager.LoadScene("EndScreen");
        } 

    }
}
