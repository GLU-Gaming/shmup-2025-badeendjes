using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
   
    public List<GameObject> objectsToSpawn = new List<GameObject>();
    //private int[] Enemies = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 2, 2, 3, 3, 2, 2, 2, 3, 3, 3, 2, 2, 3, 3, 1, 1, 1 };
    private int[] SpawnOrder = new int[] {3, 3, 5, 5, 4, 8, 4, 1, 4, 6, 7};
    private Vector3 SpawnPoint = new Vector3(10, 2, -2);
    private Vector3 MovePoint = new Vector3(7, 2, 0);
    private bool Move = false;
    private int currentPhase = 0;
    public List<GameObject> currentEnemies = new List<GameObject>();
    public MonoBehaviour refScript;
    

    private IEnumerator SpawnLoop()
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
    }
    
    private void Start()
    {
        SpawnNextWave();


    }
    private void SpawnNextWave() 
    {
        for (int i = 0; i < SpawnOrder[0]; i++)
        {
            Instantiate(objectsToSpawn[0], SpawnPoint, Quaternion.identity);
            currentEnemies.Add(objectsToSpawn[0]);
            
            objectsToSpawn.RemoveAt(0);
        }
    }
    private void Update()
    {
        
        for (int i = 0; i < currentEnemies.Count; i++)
        {
            Enemy = currentEnemies[i];
            Debug.Log(Enemy);
            if (Enemy == null)
            {
                
                Debug.Log("ITWORK");
                currentEnemies.Remove(currentEnemies[i]);
            }
        }






    }
}
