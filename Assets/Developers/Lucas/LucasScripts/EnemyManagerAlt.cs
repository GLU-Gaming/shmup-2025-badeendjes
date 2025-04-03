using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> objectsToSpawn = new List<GameObject>(); // List of gameObjects to spawn
    private Vector3 SpawnPoint = new Vector3(10, 2, 0);
    private Vector3 MovePoint = new Vector3(7, 2, 0);
    private bool Move = false;
    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (objectsToSpawn.Count > 0) // Loop while objects exist in the list
        {
            GameObject obj = objectsToSpawn[0];
            if (obj != null)
            {
                Instantiate(obj, SpawnPoint, Quaternion.identity);
                obj.transform.position = Vector3.MoveTowards(SpawnPoint, MovePoint, Time.deltaTime);
            }

            objectsToSpawn.RemoveAt(0); // Remove the spawned object from the list
            yield return null; // Allow next frame update before continuing
        }
    }
    private void Update()
    {
        
        
    }
}
