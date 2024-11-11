using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
