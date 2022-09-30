using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
   //Enemy Properties
    public GameObject player;
    public GameObject enemy;
    public float lifeTime = 1;

    //NavMeshAgent
    public NavMeshAgent _agent;

    void Update()
    {
        //Checks if object has Dead Enemy tag
        if(enemy.gameObject.tag == "Dead Enemy")
        {
            //Starts Enemy death timer
            StartCoroutine(DestroyEnemy(enemy, lifeTime));
        }
        //Makes the enemy target the player
            _agent.SetDestination(player.transform.position);


    }

    private IEnumerator DestroyEnemy(GameObject enemy, float delay)
    {
        //waits for delay
        yield return new WaitForSeconds(delay);

        Destroy(enemy);
    }
}
