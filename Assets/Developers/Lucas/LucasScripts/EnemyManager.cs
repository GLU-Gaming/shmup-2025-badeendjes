
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject ShockRay;
    [SerializeField] private GameObject Pshrimp;
    [SerializeField] private GameObject AnglerFish;

    private GameObject[] CurrentEnemies;



    private void Start()
    {
        CurrentEnemies = new GameObject[3];
    }
    private void Update()
    {

       foreach (GameObject value in CurrentEnemies) 
        {
            Instantiate(value);

        }
    }

}
