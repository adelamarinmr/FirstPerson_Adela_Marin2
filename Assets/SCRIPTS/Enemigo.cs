using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    private NavMeshAgent agent;
    private FirstPerson player;
    // Start is called before the first frame update
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();

        player = GameObject.FindObjectOfType<FirstPerson>();
    }

    // Update is called once per frame
    void Update()
    {
        //tengo que definir cpomo destino la posición del player
        agent.SetDestination(player.transform.position);
    }
}
