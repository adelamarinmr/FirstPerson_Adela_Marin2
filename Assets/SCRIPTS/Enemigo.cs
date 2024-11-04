using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    private NavMeshAgent agent;
    private FirstPerson player;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
       anim =  GetComponent<Animator>();

        player = GameObject.FindObjectOfType<FirstPerson>();
    }

    // Update is called once per frame
    void Update()
    {
        //tengo que definir cpomo destino la posición del player
        agent.SetDestination(player.transform.position);

        if (agent.remainingDistance <= agent.stoppingDistance)
        {

            agent.isStopped = true; // me paro ante él

            //Activar animación ataque

            anim.SetBool("Attack", true);
        }

    }

    #region Eventos de animacion
    private void FinAtaque()
    {
        //termino de atacar, vuelvo a moverme
        agent.isStopped = false;
        anim.SetBool("Attack", false);
    }
    #endregion


}

