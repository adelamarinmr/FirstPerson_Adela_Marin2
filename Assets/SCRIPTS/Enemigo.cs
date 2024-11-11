using System;
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
    private bool ventanaAbierta = false;

    [SerializeField] Transform attackPoint;
    [SerializeField] private float radioAtaque;
    [SerializeField] private LayerMask queEsDanable;
    [SerializeField] private float danoAtaque;
    [SerializeField] private float vidas;
    
    private Rigidbody[] huesos;


    private bool danoRealizado = false;

    public float Vidas { get => vidas; set => vidas = value; }


    // Start is called before the first frame update
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
       anim =  GetComponent<Animator>();
       GetComponentsInChildren<Rigidbody>();

        player = GameObject.FindObjectOfType<FirstPerson>();


        for (int i = 0; i < huesos.Length; i++)
        {
            huesos[i].isKinematic = true;
        }

        CambiarEstadoHuesos(true);
    }

    // Update is called once per frame
    void Update()
    {
        Perseguir();

        if (ventanaAbierta)
        {
            DetectarJugador();
        }


    }

    private void DetectarJugador()
    {
       Collider[] collsDetectados = Physics.OverlapSphere(attackPoint.position, radioAtaque, queEsDanable);
         
        if ((collsDetectados.Length>0))
        {
            for (int i = 0; i < collsDetectados.Length; i++)
            {
                collsDetectados[i].GetComponent<FirstPerson>().RecibirDano(danoAtaque);

            }
            danoRealizado = true;
        }
    }

    private void Perseguir()
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
        danoRealizado = false;
    }

    private void AbrirVentanaAtaque()
    {
        ventanaAbierta = true;
    }

    private void CerrarVentanaAtaque()
    {
        ventanaAbierta = false;
    }
    #endregion

    public void Morir()
    {
        anim.enabled = false;
        agent.enabled = false;

        CambiarEstadoHuesos(false);
        Destroy(gameObject,10);
    }

    private void CambiarEstadoHuesos(bool estado)
    {
        for (int i = 0; i < huesos.Length; i++)
        {
            huesos[i].isKinematic = estado;
        }
    }
}

