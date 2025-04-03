using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> objectsToSpawn = new List<GameObject>(); 
    private Vector3 SpawnPoint = new Vector3(10, 2, 0);
    private Vector3 MovePoint = new Vector3(7, 2, 0);
    private bool Move = false;
    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (objectsToSpawn.Count > 0) 
        {
            GameObject obj = objectsToSpawn[0];
            if (obj != null)
            {
                Instantiate(obj, SpawnPoint, Quaternion.identity);
                obj.transform.position = Vector3.MoveTowards(SpawnPoint, MovePoint, Time.deltaTime);
            }

            objectsToSpawn.RemoveAt(0); 
            yield return null; 
        }
    }
    private void Update()
    {
        
        
    }
}
