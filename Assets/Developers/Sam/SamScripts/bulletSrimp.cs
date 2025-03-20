using UnityEngine;

public class bulletSrimp : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float speed = 10f;
    private Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;
        Destroy(gameObject, 2);

    }

    private void OnCollisionEnter(Collision collision)
    {

        Destroy(gameObject);

    }
}
