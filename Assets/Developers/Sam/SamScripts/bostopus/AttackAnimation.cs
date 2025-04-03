using UnityEngine;
using System.Collections;

public class AttackAnimation : MonoBehaviour
{
    
    Animator m_Animator;
    bool isAttacking = false;

    private enum atackState { 
        stab,
        smack
    
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){

        m_Animator = gameObject.GetComponent<Animator>();
    }

    IEnumerator Attack(float delay)
    {
        Debug.Log("Starting attack!");
        isAttacking = true;
       
        yield return new WaitForSeconds(delay);
        int rng = Random.Range(0, 2);
        if (rng == (int)atackState.stab)
        {
            m_Animator.SetTrigger("stab");
        }
        else if (rng == (int)atackState.smack)
        {
            m_Animator.SetTrigger("smack");
        }
        Debug.Log("Done waiting!");
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space)) {
        //    m_Animator.SetTrigger("smack");
        
        //}

        if (isAttacking == false)
        {
            StartCoroutine(Attack(5.0f));
        }
    }
}
