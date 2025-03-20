using UnityEngine;
using UnityEngine.UIElements;

public class CameraRunner : MonoBehaviour
{
    [SerializeField] Transform player;
    


    private void Start()
    {
      
    }

 

    private void Update()
    {
        transform.position = new Vector3(player.position.x, 02, -20);
    }

}
