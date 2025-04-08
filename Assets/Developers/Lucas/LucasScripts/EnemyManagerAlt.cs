using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    public GameObject Bocto;
    public List<GameObject> objectsToSpawn = new List<GameObject>();
    //private int[] Enemies = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 2, 2, 3, 3, 2, 2, 2, 3, 3, 3, 2, 2, 3, 3, 1, 1, 1 };
    private int[] SpawnOrder = new int[] {3, 3, 5, 5, 4, 8, 4, 1, 4, 6, 7, 1};
    private int Order = 0;
    private Vector3 SpawnPoint = new Vector3(10, 0, -2);
    private Vector3 MovePoint = new Vector3(7, 2, 0);
    private bool Move = false;
    private int currentPhase = 0;
    public List<GameObject> currentEnemies = new List<GameObject>();
    public MonoBehaviour refScript;
    public int Object = 0;
    public AudioSource bossFightMusic;
    public AudioSource fightMusic;
    

   /* private IEnumerator SpawnLoop()
    {
        while (objectsToSpawn.Count > 0) 
        {
            GameObject obj = objectsToSpawn[0];
            if (obj != null)
            {
                for (int i = 0; i > SpawnOrder[currentPhase]; i++)
                {
                    Instantiate(obj, SpawnPoint, Quaternion.identity);

                }
                
            }

            objectsToSpawn.RemoveAt(0); 
            yield return null; 
        } 
    } */
    
    private void Start()
    {
        StartCoroutine(SpawnNextWave());


    }
    private IEnumerator SpawnNextWave() 
    {
        while (SpawnOrder[Order] > currentEnemies.Count)
        {
            SpawnPoint.y = Random.Range(1f, 8f);
            if (objectsToSpawn[Object] != Bocto)
            {
                GameObject go = Instantiate(objectsToSpawn[Object], SpawnPoint, Quaternion.identity);
                currentEnemies.Add(go);
            }
            if (objectsToSpawn[Object] == Bocto) 
            {
                fightMusic.Stop();
                bossFightMusic.Play();
                SpawnPoint.y = 0f;
                GameObject go = Instantiate(objectsToSpawn[Object], SpawnPoint, Quaternion.identity);
                currentEnemies.Add(go);

            }

                Object++;

            yield return new WaitForSeconds(1);
            
        }
        Object = 0;
    }
    private void Update()
    {
        if (objectsToSpawn == null) 
        {
            SceneManager.LoadScene("YouWinScreen");
        }
        for (int i = 0; i < currentEnemies.Count; i++)
        {
           
            if (currentEnemies[i] == null)
            {
                Debug.Log("GRAAAAAAAGHHHHHH");
             
                currentEnemies.Remove(currentEnemies[i]);
                objectsToSpawn.Remove(objectsToSpawn[i]);
            }
        }

        if (currentEnemies.Count <= 0) 
        {
            Order = Order + 1;
            StartCoroutine(SpawnNextWave());
        
        
        }
        






    }
}
