using UnityEngine;
using static UnityEngine.ParticleSystem;

public abstract class enemybase : MonoBehaviour
{
    //adjust this to change speed
    [SerializeField] float speed = 5f;
    //adjust this to change how high it goes
    [SerializeField] float height = 3f;

    [SerializeField] float fireRate = 0f;
    private float nextFireTime = 0f;

    [SerializeField] float maxHealth = 50f;
    private float currentHealth;

    Vector3 pos;
    [SerializeField] GameObject particle;

    [SerializeField] tijdelijkWin tijdelijkWin;


    public virtual void Start()
    {
        pos = transform.position;
        currentHealth = maxHealth;
        
    }

    public virtual void Update()
    {
        Movement();

        if (Time.time >= nextFireTime)
        {

            Attack();
            nextFireTime = Time.time + fireRate;

        }

    }

    public virtual void Movement()
    {
        //calculate what the new Y position will be
        float newY = (Mathf.Sin(Time.time * speed) * height) + pos.y;
        //set the object’s Y to the new calculated Y
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    protected virtual void Attack()
    {

    }

    protected virtual void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.tag == "bullets") {

            Instantiate(particle, transform.position, transform.rotation);
            currentHealth = currentHealth - 1;
            checkIfDead();
        }
    
    }

    protected virtual void checkIfDead() {
        if (currentHealth <= 0) {
           
            Destroy(gameObject);
            //tijdelijkWin.enemyDead();
        
        }
    
    }

}
