using UnityEngine;

public class shrimpmain : enemybase
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    //adjust this to change speed
    [SerializeField] float srimpSpeed = 5f;
    //adjust this to change how high it goes
    [SerializeField] float srimpHeight = 3f;
    [SerializeField] float srimpWaves;
    [SerializeField] float srimpLength = 3f;

    Vector3 srimpPos;

    public override void Start()
    {
        base.Start();
        srimpPos = transform.position;
    }


    protected override void Attack()
    {
        Shoot();
    }

    public override void Movement()
    {
        //base.Movement();
        float newY = Mathf.Sin(Time.time * (srimpSpeed*srimpWaves)) * srimpHeight + srimpPos.y;
        //float newX = -Mathf.Sin(Time.time * srimpSpeed) * srimpLength + srimpPos.x;
        float newX = srimpPos.x - (Mathf.PingPong(Time.time, srimpLength) * srimpSpeed);
        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    protected void Shoot()
    {
        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

}
