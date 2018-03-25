using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Basic_Move : MonoBehaviour
{
    Transform player;       
    Player_Health playerHealth;
    Enemy_Health enemyHealth;
    NavMeshAgent nav;

    void Awake()
    {
        // Set up the references.
        player = GameObject.Find("Player").transform;
        playerHealth = player.GetComponent<Player_Health>();
        enemyHealth = GetComponent<Enemy_Health>();
        nav = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (enemyHealth.cur_health > 0 && playerHealth.cur_health > 0)
        {
            nav.SetDestination(player.position);
        }
        else
        {
            // Disable the nav mesh agent.
            nav.enabled = false;
        }
    }
}