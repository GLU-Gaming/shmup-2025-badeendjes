using UnityEngine;

public class shrimpmain : enemybase
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;


    protected override void Attack()
    {
        Shoot();
    }

    protected void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

}
