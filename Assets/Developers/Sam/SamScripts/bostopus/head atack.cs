using UnityEngine;

public class headatack : MonoBehaviour
{
    [SerializeField] float fireRate = 0f;
    private float nextFireTime = 0f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {

            Attack();
            nextFireTime = Time.time + fireRate;

        }
    }

    private void Attack() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
