using UnityEngine;
using System.Collections;


public class Basic_Attack : MonoBehaviour
{
    public float gap = 0.5f;
    public int attackDamage = 6;

    GameObject player;
    Player_Health playerHealth;
    Enemy_Health enemyHealth;
    bool playerInRange;
    float timer;

    void Awake()
    {
        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<Player_Health>();
        enemyHealth = GetComponent<Enemy_Health>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update()
    {
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= gap && playerInRange && enemyHealth.cur_health > 0)
        {
            Attack();
        }
    }


    void Attack()
    {
        // Reset the timer.
        timer = 0f;

        if (playerHealth.cur_health > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}