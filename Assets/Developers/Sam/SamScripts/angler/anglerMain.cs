using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class anglerMain : enemybase
{

    [SerializeField] private float resetTime = 3.0f;
    [SerializeField] private float anglerSpeed = 1.0f;
    [SerializeField] private float timer = 0.0f;

    Vector3 idlePosition;

    public AudioSource stingrayAttack;
    public AudioSource enemyHit;

    private enum EnemyState {
        Idle,
        Agro,
        Return
    };

    private enum Direction
    {
        Left = -1,
        Right = 1
    }

    private int currentState = (int) EnemyState.Idle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && currentState == (int) EnemyState.Idle)
        {
            Debug.Log("Trigger!");
            currentState = (int)EnemyState.Agro;
        }
    }

    public override void Start()
    {
        base.Start();
        timer = resetTime;
        idlePosition = transform.position;
    }

    private void IdleEnemyState()
    {
        base.Update();
    }

    private void ReturnEnemyState()
    {
        if (transform.position.x < idlePosition.x)
        {
            transform.position += new Vector3((int)Direction.Right * anglerSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            currentState = (int) EnemyState.Idle;
        }
    }

    private void AgroEnemyState()
    {
        // Reset enemy state to idle when timer is over. To do: or when enemy hits the player
        if (timer < 0.0f)
        {
            currentState = (int) EnemyState.Return;
            timer = resetTime;
            return;
        }
        stingrayAttack.Play();
        transform.position += new Vector3((int) Direction.Left * anglerSpeed * Time.deltaTime, 0, 0);
        timer -= Time.deltaTime;
    }

    public override void Update()
    {
        switch (currentState)
        {
            case (int)EnemyState.Idle:
                IdleEnemyState();
                break;
            case (int)EnemyState.Agro:
                AgroEnemyState();
                break;
            case (int)EnemyState.Return:
                ReturnEnemyState();
                break;
            default:
                break;
        }

    }
    public override void damageSound()
    {
        enemyHit.Play();
        base.damageSound();
    }
}
