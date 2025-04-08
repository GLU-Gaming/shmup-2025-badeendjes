using TMPro;
using UnityEngine;

public class eindScherm : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI puntenText;
    public float punten = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        punten = PlayerPrefs.GetFloat("timeScore");

        string output = "" + punten;

        output = output.PadLeft(4, '0');


        puntenText.text = output;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
