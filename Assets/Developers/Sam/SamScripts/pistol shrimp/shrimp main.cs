using UnityEngine;
using static UnityEditor.PlayerSettings;

public class shrimpmain : enemybase
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    //adjust this to change speed
    [SerializeField] float srimpSpeed = 5f;
    //adjust this to change how high it goes
    [SerializeField] float srimpHeight = 3f;

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
        //custom movement van de shrimp kan hier
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * srimpSpeed) * srimpHeight + srimpPos.y;
        float newX = -Mathf.Sin(Time.time * srimpSpeed) * srimpHeight + srimpPos.x;
        //set the object’s Y to the new calculated Y
        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    protected void Shoot()
    {
        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

}
