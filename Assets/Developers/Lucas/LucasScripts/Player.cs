using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 jump;
    public bool grounded;
    [SerializeField] private float jumpForce = 8.0f;
    [SerializeField] private float movingSpeed = 30f;

    private bool cantBeHit = false;
    private float cantBeHitCounter;
   
    private bool isInvincible;
    private float invincibleTimer;
    private float dashCooldownCounter;
    [SerializeField] private GameObject dashParticle;
    [SerializeField] private BoxCollider Collider;
    private float Direction;


    gameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemybullet") && !isInvincible && !cantBeHit) 
        {
            gameManager.ReportPlayerHit();
            cantBeHit = true;
            
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        grounded = true;
    }
    private void OnCollisionExit()
    {
        grounded = false;
    }

    void FixedUpdate()
    {
       
        rb.AddForce(Input.GetAxisRaw("Horizontal") * movingSpeed, 0f, 0f);
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            grounded = false;
            
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }
    }
    private void Update()
    {
        Direction = Input.GetAxisRaw("Horizontal") * movingSpeed;


       if (Input.GetKey(KeyCode.LeftShift) && dashCooldownCounter >= 2f) 
       {
            isInvincible = true;
            dashCooldownCounter = 0;
       }
       

        if (isInvincible) 
        {
            //Instantiate(dashParticle, particlePoint.position, particlePoint.rotation);
            movingSpeed = 100f;
            invincibleTimer += Time.deltaTime;
            dashParticle.SetActive(true);
            Collider.enabled = false;

        }
        else 
        { 
            movingSpeed = 30f;
            dashCooldownCounter += Time.deltaTime;
            dashParticle.SetActive(false);
            Collider.enabled = true;
        }
        if (invincibleTimer >= 0.4) 
        {
            if (Direction >= 0)
            {
                rb.AddForce(movingSpeed * -14, 0, 0);
            }
            if (Direction <= 0)
            {
                rb.AddForce(movingSpeed * 14, 0, 0);
            }

            isInvincible = false;
            invincibleTimer = 0;
        }

        //LiveCounter.text = ("Lives = " + lives).ToString();

         
        if (cantBeHit == true) 
        {
            cantBeHitCounter += Time.deltaTime;
        }
        if (cantBeHitCounter >= 2f) 
        {
            cantBeHit = false;
            cantBeHitCounter = 0;
        } 
        
    } 

    public void Youwin() 
    {
        SceneManager.LoadScene("YouWinScreen");
    }



}
