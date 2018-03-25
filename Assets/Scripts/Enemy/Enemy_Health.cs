using UnityEngine;
using UnityEngine.AI;

public class Enemy_Health : MonoBehaviour
{
    public int max_health = 100;
    public int cur_health;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;

    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;

    void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        cur_health = max_health;
    }

    void Update()
    {
        if (isSinking)
        {
            // sinking it.
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (isDead)
        {
            return;
        }

        // setting effect position. 
        // transform.position = hitPoint;

        cur_health -= amount;
        if (cur_health <= 0)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;
        // making it stop and 'transparent'
        capsuleCollider.isTrigger = true;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;

        isSinking = true;
        Destroy(gameObject, 2f);
    }
}