using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
