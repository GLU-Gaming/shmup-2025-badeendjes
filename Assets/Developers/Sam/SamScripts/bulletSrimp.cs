using System.Collections;
using UnityEngine;

public class bulletSrimp : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float speed = 10f;
    [SerializeField] float time = 10;
    [SerializeField] float size = 5;
    [SerializeField] float desTime = 2;
    [SerializeField] float growSpeed;
    private float siseX = 0.2f;
    private float siseZ = 0.2f;

    private float currentTime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;
        StartCoroutine(ScaleOverTime(time));
        Destroy(gameObject, desTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
        Destroy(gameObject);
        

    }

    private IEnumerator ScaleOverTime(float duration)
    {
        currentTime = 0;
        while (duration >= currentTime)
        {
            currentTime += Time.deltaTime * growSpeed;
            transform.localScale = new Vector3(siseX, Mathf.Lerp(transform.localScale.y, size, currentTime / time), siseZ);
            yield return null;
        }

    }
}
