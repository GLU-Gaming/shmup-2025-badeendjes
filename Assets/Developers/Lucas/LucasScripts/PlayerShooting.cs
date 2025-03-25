using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private float Cooldown = 1f;
    private float cooldownCounter;
    private bool isShooting;
    

   
    void Update()
    {
        /*if (Input.GetMouseButton(0)) 
        {
            if (cooldownCounter >= Cooldown) {
                Debug.Log("POW");
                Instantiate(Bullet, transform.position, transform.rotation);
                cooldownCounter = 0;
            } 
        }
        cooldownCounter += Time.deltaTime;*/

        if (Input.GetMouseButtonDown(0) && !isShooting)
        {
            StartCoroutine(Shoot());
        }

        if (Input.GetMouseButtonUp(0))
            isShooting = false;
    }

    private IEnumerator Shoot()
    {
        isShooting = true;
        while (isShooting)
        {
           
            Instantiate(Bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(Cooldown);
        }
    }
    
    
}
