using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerMovement : MonoBehaviour
{

    public Vector3 jump;
    [SerializeField] public float jumpForce = 8.0f;

    public bool grounded;
    private Rigidbody rb;

    void Start()
    {
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        rb = GetComponent<Rigidbody>();
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
        rb.AddForce(Input.GetAxisRaw("Horizontal") * 50f, 0f, 0f);
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            grounded = false;
            
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            
        }
    }
    
    
}
