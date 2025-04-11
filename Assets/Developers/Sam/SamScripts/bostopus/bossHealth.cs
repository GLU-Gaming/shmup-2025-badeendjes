using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.SceneManagement;

public class bossHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 50f;
    private float currentHealth;
    [SerializeField] GameObject particle;

    public AudioSource enemyHit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        enemyHit.Play();
        if (collision.gameObject.tag == "bullets")
        {
            Instantiate(particle, transform.position, transform.rotation);
            currentHealth = currentHealth - 1;
            checkIfDead();
        }

        if (collision.gameObject.tag == "SwordBullets")
        {

            Instantiate(particle, transform.position, transform.rotation);
            currentHealth = currentHealth - 5;
            checkIfDead();
        }

    }

    private void checkIfDead()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("YouWinScreen");


        }

    }
}
