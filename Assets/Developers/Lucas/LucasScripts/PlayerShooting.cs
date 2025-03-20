using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private float Cooldown = 1f;
    private float cooldownCounter;
    

   
    void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            if (cooldownCounter >= Cooldown) {
                Debug.Log("POW");
                Instantiate(Bullet, transform.position, transform.rotation);
                cooldownCounter = 0;
            } 
        }
        cooldownCounter += Time.deltaTime;

    }
    
    private void OnMouse()
    {
        Debug.Log("POW");
        Instantiate(Bullet, transform.position, transform.rotation);
    }
}
