using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPart : MonoBehaviour
{
    [SerializeField] private Enemigo mainScript;
    [SerializeField] float multiplicadorDanho;

    public void RecibirDanho(float danhoRecibido)
    {

        mainScript.Vidas -= danhoRecibido * multiplicadorDanho;
        if (mainScript.Vidas <= 0)
        {
            mainScript.Morir();
        }

    }

    public void Explotar()
    {
        mainScript.GetComponent<Animator>().enabled = false;
        mainScript.GetComponent<NavMeshAgent>().enabled = false;
        mainScript.enabled = false;
    }
}
