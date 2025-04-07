using UnityEngine;

public class destroyAfterSeconds : MonoBehaviour
{
    [SerializeField] float Time = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject,Time);
    }

}
