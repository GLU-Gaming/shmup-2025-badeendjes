using UnityEngine;

public class bulletRay : MonoBehaviour
{

    private Rigidbody rb;
    [SerializeField] float speed = 10f;
    [SerializeField] float desTime = 2;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;
        Destroy(gameObject, desTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
        Destroy(gameObject);

    }
}
