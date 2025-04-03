using UnityEngine;

public class bossHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 50f;
    private float currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "bullets")
        {

            currentHealth = currentHealth - 1;
            checkIfDead();
        }

    }

    private void checkIfDead()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
           

        }

    }
}
