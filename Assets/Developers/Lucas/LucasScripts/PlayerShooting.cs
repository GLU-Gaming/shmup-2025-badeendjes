using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject Shrimp;
    [SerializeField] private GameObject SwordFish;
    [SerializeField] private float Cooldown = 1f;
    private float cooldownCounter;
    private bool isShooting;
    private bool shrimpWeaponActive;
    private GameObject currentWeapon;
    public AudioSource shrimpShoot;
    public AudioSource swordShoot;

    private void Start()
    {
        currentWeapon = Shrimp; 
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (cooldownCounter >= Cooldown)
            {
                Debug.Log("POW");
                Instantiate(currentWeapon, transform.position, transform.rotation);
                cooldownCounter = 0;
                if (shrimpWeaponActive) 
                {
                    shrimpShoot.Play();
                }
                else if (!shrimpWeaponActive) 
                {
                    swordShoot.Play();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && shrimpWeaponActive)
        {
            shrimpWeaponActive = false;
            currentWeapon = SwordFish;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && !shrimpWeaponActive)
        {
            shrimpWeaponActive = true;
            currentWeapon = Shrimp;
        }
        cooldownCounter += Time.deltaTime;

        /*if (Input.GetMouseButtonDown(0) && !isShooting)
        {
            StartCoroutine(Shoot());
        }

        if (Input.GetMouseButtonUp(0))
            isShooting = false;
   

    private IEnumerator Shoot()
    {
        isShooting = true;
        while (isShooting)
        {
           
            Instantiate(Bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(Cooldown);
        }
    }*/


    }
}
