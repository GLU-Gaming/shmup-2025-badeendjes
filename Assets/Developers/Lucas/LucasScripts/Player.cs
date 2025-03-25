using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 jump;
    public bool grounded;
    [SerializeField] private float jumpForce = 8.0f;
    [SerializeField] private float movingSpeed = 30f;


    private bool isInvincible;
    private int lives = 3;
    
    

    void Start()
    {
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullets") && !isInvincible) 
        {
            lives = lives - 1;
        }
    }
    void OnCollisionStay()
    {
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
       if(Input.GetKey(KeyCode.LeftShift)) 
       {
            isInvincible = true;
       }
       else 
       {
            isInvincible = false;
       }

        if (isInvincible) 
        {
            movingSpeed = 150f;
        }
        else 
        { 
            movingSpeed = 30f; 
        }
    }



}
