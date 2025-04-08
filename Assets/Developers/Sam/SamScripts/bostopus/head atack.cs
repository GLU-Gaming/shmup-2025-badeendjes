using UnityEngine;

public class headatack : MonoBehaviour
{
    [SerializeField] float fireRate = 0f;
    private float nextFireTime = 0f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    public AudioSource bossShoot;

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            bossShoot.Play();
            Attack();
            nextFireTime = Time.time + fireRate;

        }
    }

    private void Attack() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
