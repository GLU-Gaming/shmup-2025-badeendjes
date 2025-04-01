using UnityEngine;

public class rayMain : enemybase
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    //adjust this to change speed
    [SerializeField] float raySpeed = 5f;
    //adjust this to change how high it goes
    [SerializeField] float rayHeight = 3f;
    [SerializeField] float rayWaves;
    [SerializeField] float rayLength = 3f;

    Vector3 rayPos;

    protected override void Attack()
    {
        Shoot();
        rayPos = transform.position;
        float newY = Mathf.Sin(Time.time * (raySpeed * rayWaves)) * rayHeight + rayPos.y;
        float newX = -Mathf.Sin(Time.time * raySpeed) * rayLength + rayPos.x;
        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    protected void Shoot()
    {

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public override void Movement()
    {
        
    }
}
