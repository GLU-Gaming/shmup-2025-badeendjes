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

    


    public override void Start()
    {
        base.Start();
        rayPos = transform.position;
    }

    protected override void Attack()
    {
        Shoot();
    }

    protected void Shoot()
    {

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public override void Movement()
    {
        float newY = Mathf.Sin(Time.time * (raySpeed * rayWaves)) * rayHeight + rayPos.y;
        //newX = -Mathf.Sin(Time.time * raySpeed) * rayLength + rayPos.x;
        float newX = rayPos.x - (Mathf.PingPong(Time.time, rayLength) * raySpeed);
        transform.position = new Vector3(newX, newY, transform.position.z);
    }
}
